using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Drawing;

namespace popmsg
{
    public static class XmlHelper
    {
        public static void ToXmlNode(object obj, XmlElement xmNode)
        {
            if (obj == null)
            {
                xmNode.SetAttribute("IsNull", "True");
                return;
            }
            if (Convert.IsDBNull(obj))
            {
                xmNode.SetAttribute("IsDBNull", "True");
                return;
            }
            Type type = obj.GetType();

            #region 基本类型
            if (type == typeof(string))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Guid))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Rectangle))
            {
                Rectangle rt = (Rectangle)obj;
                xmNode.InnerText = string.Format("{0},{1},{2},{3}", rt.X, rt.Y, rt.Width, rt.Height);
                return;
            }
            if (type == typeof(char))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(bool))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(byte))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(short))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(int))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(long))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(decimal))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(float))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(double))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(byte[]))
            {
                //xmNode.InnerText = Convert.ToBase64String((byte[])obj);
                xmNode.InnerText = JsonHelper.Encode((byte[])obj);
                return;
            }
            if (type == typeof(DateTime))
            {
                xmNode.InnerText = ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss");
                return;
            }
            if (type == typeof(Nullable<char>))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Nullable<bool>))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Nullable<short>))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Nullable<int>))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Nullable<long>))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Nullable<decimal>))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Nullable<float>))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Nullable<double>))
            {
                xmNode.InnerText = obj.ToString();
                return;
            }
            if (type == typeof(Nullable<DateTime>))
            {
                xmNode.InnerText = ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss");
                return;
            }


            if (type == typeof(DataSet))
            {
                XmlNode xmTs = xmNode.OwnerDocument.CreateElement("Ts");
                xmNode.AppendChild(xmTs);
                foreach (DataTable tmpT in ((DataSet)obj).Tables)
                {
                    XmlElement xmT = xmNode.OwnerDocument.CreateElement("T");
                    xmT.SetAttribute("Name", tmpT.TableName);
                    xmTs.AppendChild(xmT);

                    XmlNode xmCs = xmNode.OwnerDocument.CreateElement("Cs");
                    xmT.AppendChild(xmCs);
                    foreach (DataColumn tmpC in tmpT.Columns)
                    {
                        XmlElement xmC = xmNode.OwnerDocument.CreateElement("C");
                        xmC.SetAttribute("Name", tmpC.ColumnName);
                        xmC.SetAttribute("Type", tmpC.DataType.FullName);
                        xmCs.AppendChild(xmC);
                    }

                    XmlNode xmRs = xmNode.OwnerDocument.CreateElement("Rs");
                    xmT.AppendChild(xmRs);
                    foreach (DataRow tmpR in tmpT.Rows)
                    {
                        XmlElement xmR = xmNode.OwnerDocument.CreateElement("R");
                        xmRs.AppendChild(xmR);

                        XmlElement xmEs = xmNode.OwnerDocument.CreateElement("Es");
                        xmR.AppendChild(xmEs);
                        for (int i = 0; i < tmpT.Columns.Count; i++)
                        {
                            XmlElement xmE = xmNode.OwnerDocument.CreateElement("E");
                            xmEs.AppendChild(xmE);
                            ToXmlNode(tmpR[i], xmE);
                        }
                    }
                }
                return;
            }
            #endregion

            #region 自定义类型
            if (type == typeof(PLocaltion)
                || type == typeof(MvOrder)
                || type == typeof(SpeedLevel)
                || type == typeof(PlayOrder)
                )
            {
                int flag = (int)obj;
                xmNode.InnerText = flag.ToString();
                return;
            }
            #endregion

            #region 其它类型
            if (type.IsGenericType)
            {

                if (type.GetGenericTypeDefinition() != typeof(List<>))
                {
                    if (type.FullName.Contains("SearchModel"))
                    {

                        foreach (MethodInfo m in type.GetMethods())
                        {
                            if (m.Name == "ToXmlNode")
                            {
                                XmlElement xmSM = xmNode.OwnerDocument.CreateElement("SMS");
                                XmlElement xmObj = (XmlElement)m.Invoke(obj, new object[] { xmSM });
                                xmNode.AppendChild(xmObj);
                                break;
                            }
                        }
                        return;
                    }
                    else
                    {
                        throw new ExSys("Unknown type \"{0}\"!", type.FullName);
                    }
                }




                Type[] genericTypes = type.GetGenericArguments();
                if (genericTypes.Length != 1)
                {
                    throw new ExSys("Unknown type \"{0}\"!", type.FullName);
                }
                Type itemType = genericTypes[0];

                PropertyInfo[] objPIs = type.GetProperties();
                int objItemCount = 0;
                foreach (PropertyInfo objPI in objPIs)
                {
                    if (objPI.Name != "Count")
                    {
                        continue;
                    }
                    objItemCount = (int)objPI.GetValue(obj, null);
                    break;
                }
                foreach (PropertyInfo objPI in objPIs)
                {
                    if (objPI.Name != "Item")
                    {
                        continue;
                    }
                    for (int i = 0; i < objItemCount; i++)
                    {
                        object itemObj = objPI.GetValue(obj, new object[] { i });
                        XmlElement itemNode = xmNode.OwnerDocument.CreateElement(xmNode.Name + "_item");
                        ToXmlNode(itemObj, itemNode);
                        xmNode.AppendChild(itemNode);
                    }
                    break;
                }
                return;
            }
            if (type.IsClass)
            {
                //if (!type.Namespace.StartsWith("JS"))
                //{
                //    throw new ExSys("Unknown type \"{0}\"!", type.FullName);
                //}

                PropertyInfo[] PIs = type.GetProperties();
                foreach (PropertyInfo tmpPI in PIs)
                {
                    if (!tmpPI.CanRead || !tmpPI.CanWrite)
                    {
                        continue;
                    }
                    object propertyObj = tmpPI.GetValue(obj, null);
                    XmlElement propertyNode = xmNode.OwnerDocument.CreateElement(tmpPI.Name);
                    ToXmlNode(propertyObj, propertyNode);
                    xmNode.AppendChild(propertyNode);
                }
                return;
            }
            #endregion

            throw new ExSys("Unknown type \"{0}\"!", type.FullName);
        }
        private static object FromXmlNode<T>(Type type, XmlElement xmNode)
        {
            if (xmNode.HasAttribute("IsNull"))
            {
                return null;
            }
            if (xmNode.HasAttribute("IsDBNull"))
            {
                return Convert.DBNull;
            }


            #region 基本数据类型
            if (type == typeof(Guid))
            {
                return xmNode.InnerText;
            }
            if (type == typeof(string))
            {
                return xmNode.InnerText;
            }
            if (type == typeof(char))
            {
                return char.Parse(xmNode.InnerText);
            }
            if (type == typeof(Rectangle))
            {
                string[] strs = xmNode.InnerText.Split(',');
                if (strs.Length != 4)
                {
                    throw new ExSys("Unknow Rectangle");
                }
                Rectangle r = new Rectangle();
                r.X = int.Parse(strs[0]);
                r.Y = int.Parse(strs[1]);
                r.Width = int.Parse(strs[2]);
                r.Height = int.Parse(strs[3]);
                return r;
            }
            if (type == typeof(bool))
            {
                switch (xmNode.InnerText.ToUpper())
                {
                    case "TRUE":
                    case "Y":
                    case "1":
                        return true;
                    default:
                        return false;
                }
            }

            if (type == typeof(short))
            {
                return short.Parse(xmNode.InnerText);
            }
            if (type == typeof(byte))
            {
                return byte.Parse(xmNode.InnerText);
            }
            if (type == typeof(int))
            {
                return int.Parse(xmNode.InnerText);
            }
            if (type == typeof(long))
            {
                return long.Parse(xmNode.InnerText);
            }
            if (type == typeof(decimal))
            {
                return decimal.Parse(xmNode.InnerText);
            }
            if (type == typeof(float))
            {
                return float.Parse(xmNode.InnerText);
            }
            if (type == typeof(double))
            {
                return double.Parse(xmNode.InnerText);
            }
            if (type == typeof(byte[]))
            {
                // byte[] obj = Convert.FromBase64String(xmNode.InnerText);
                byte[] obj = JsonHelper.Decode<byte[]>(xmNode.InnerText);
                return obj;
            }
            if (type == typeof(DateTime))
            {
                return DateTime.Parse(xmNode.InnerText);
            }
            if (type == typeof(Nullable<char>))
            {
                return short.Parse(xmNode.InnerText);
            }
            if (type == typeof(Nullable<bool>))
            {
                switch (xmNode.InnerText.ToUpper())
                {
                    case "TRUE":
                    case "Y":
                    case "1":
                        return true;
                    default:
                        return false;
                }
            }
            if (type == typeof(Nullable<short>))
            {
                return short.Parse(xmNode.InnerText);
            }
            if (type == typeof(Nullable<int>))
            {
                return int.Parse(xmNode.InnerText);
            }
            if (type == typeof(Nullable<long>))
            {
                return long.Parse(xmNode.InnerText);
            }
            if (type == typeof(Nullable<decimal>))
            {
                return decimal.Parse(xmNode.InnerText);
            }
            if (type == typeof(Nullable<float>))
            {
                return float.Parse(xmNode.InnerText);
            }
            if (type == typeof(Nullable<double>))
            {
                return float.Parse(xmNode.InnerText);
            }
            if (type == typeof(Nullable<DateTime>))
            {
                return DateTime.Parse(xmNode.InnerText);
            }
            if (type == typeof(DataSet))
            {
                DataSet obj = new DataSet();
                XmlNode xmTs = xmNode.SelectSingleNode("Ts");
                if (xmTs == null)
                {
                    throw new ExSys("Xml node \"Ts\" not found!");
                }
                foreach (XmlNode xmT in xmTs.SelectNodes("T"))
                {
                    DataTable tmpT = new DataTable();
                    obj.Tables.Add(tmpT);
                    if (!((XmlElement)xmT).HasAttribute("Name"))
                    {
                        throw new ExSys("Xml node \"T\" does not include attribute \"Name\"!");
                    }
                    tmpT.TableName = xmT.Attributes["Name"].Value;

                    XmlNode xmCs = xmT.SelectSingleNode("Cs");
                    if (xmCs == null)
                    {
                        throw new ExSys("Xml node \"Cs\" not found!");
                    }
                    foreach (XmlNode xmC in xmCs.SelectNodes("C"))
                    {
                        if (!((XmlElement)xmC).HasAttribute("Name"))
                        {
                            throw new ExSys("Xml node \"C\" does not include attribute \"Name\"!");
                        }
                        if (!((XmlElement)xmC).HasAttribute("Type"))
                        {
                            throw new ExSys("Xml node \"C\" does not include attribute \"Type\"!");
                        }
                        tmpT.Columns.Add(xmC.Attributes["Name"].Value, Type.GetType(xmC.Attributes["Type"].Value));
                    }

                    XmlNode xmRs = xmT.SelectSingleNode("Rs");
                    if (xmRs == null)
                    {
                        throw new ExSys("Xml node \"Rs\" not found!");
                    }
                    foreach (XmlNode xmR in xmRs.SelectNodes("R"))
                    {
                        XmlNode xmEs = xmR.SelectSingleNode("Es");
                        if (xmEs == null)
                        {
                            throw new ExSys("Xml node \"Es\" not found!");
                        }
                        if (xmEs.ChildNodes.Count != tmpT.Columns.Count)
                        {
                            throw new ExSys("xmEs.ChildNodes.Count != tmpT.Columns.Count");
                        }
                        DataRow tmpE = tmpT.NewRow();
                        tmpT.Rows.Add(tmpE);
                        for (int i = 0; i < tmpT.Columns.Count; i++)
                        {
                            tmpE[i] = FromXmlNode<T>(tmpT.Columns[i].DataType, (XmlElement)xmEs.ChildNodes[i]);
                        }
                    }
                }
                return obj;
            }
            #endregion

            #region 自定义类型


            if (type == typeof(PLocaltion)
                || type == typeof(MvOrder)
                || type == typeof(SpeedLevel)
                || type == typeof(PlayOrder)
                )
            {
                return Enum.Parse(type, xmNode.InnerText);
            }
            #endregion

            #region 其它类型
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() != typeof(List<>))
                {
                    if (type.FullName.Contains("SearchModel"))
                    {
                        T rets = Activator.CreateInstance<T>();
                        foreach (MethodInfo m in type.GetMethods())
                        {
                            if (m.Name == "FromXmlNode")
                            {
                                m.Invoke(rets, new object[] { xmNode });
                                break;
                            }
                        }
                        return rets;
                    }
                    else
                    {
                        throw new ExSys("Unknown type \"{0}\"!", type.FullName);
                    }
                }
                Type[] genericTypes = type.GetGenericArguments();
                if (genericTypes.Length != 1)
                {
                    throw new ExSys("Unknown type \"{0}\"!", type.FullName);
                }
                Type itemType = genericTypes[0];

                object obj = Activator.CreateInstance(type, true);
                foreach (XmlElement itemNode in xmNode.SelectNodes(xmNode.Name + "_item"))
                {
                    object itemObj = FromXmlNode<T>(itemType, itemNode);
                    type.GetMethod("Add").Invoke(obj, new object[] { itemObj });
                }
                return obj;
            }
            if (type.IsClass)
            {
                //if (!type.Namespace.StartsWith("JS"))
                //{
                //    throw new ExSys("Unknown type \"{0}\"!", type.FullName);
                //}

                object obj = Activator.CreateInstance(type, true);
                PropertyInfo[] PIs = type.GetProperties();
                foreach (PropertyInfo tmpPI in PIs)
                {
                    if (!tmpPI.CanRead || !tmpPI.CanWrite)
                    {
                        continue;
                    }
                    XmlElement propertyNode = (XmlElement)xmNode.SelectSingleNode(tmpPI.Name);
                    if (propertyNode == null)
                    {
                        continue;
                    }

                    Type propertyType = tmpPI.PropertyType;
                    object propertyObj = FromXmlNode<T>(propertyType, propertyNode);
                    tmpPI.SetValue(obj, propertyObj, null);
                }
                return obj;
            }
            #endregion

            throw new ExSys("Unknown type \"{0}\"!", type.FullName);
        }

        public static XmlDocument GetXmlDocument(object obj)
        {
            XmlDocument xmDoc = new XmlDocument();
            XmlElement xmNode = xmDoc.CreateElement("XL");
            ToXmlNode(obj, xmNode);
            xmDoc.AppendChild(xmNode);
            return xmDoc;
        }
        public static string GetOuterXml(object obj)
        {
            XmlDocument xmDoc = GetXmlDocument(obj);
            return xmDoc.OuterXml;
        }
        public static void ToFile(object obj, string filePath)
        {
            if (File.Exists(filePath))
            {
                throw new ExSys("The file \"{0}\" exists!", filePath);
            }
            XmlDocument xmDoc = GetXmlDocument(obj);
            xmDoc.Save(filePath);
        }

        public static T FromXmlDocument<T>(XmlDocument xmDoc)
        {
            return (T)FromXmlNode<T>(typeof(T), xmDoc.DocumentElement);
        }
        public static T FromOuterXml<T>(string outerXml)
        {
            XmlDocument xmDoc = new XmlDocument();
            xmDoc.LoadXml(outerXml);
            return FromXmlDocument<T>(xmDoc);
        }
        public static T FromFile<T>(string filePath)
        {
            XmlDocument xmDoc = new XmlDocument();
            xmDoc.Load(filePath);
            return FromXmlDocument<T>(xmDoc);
        }
    }   

}
