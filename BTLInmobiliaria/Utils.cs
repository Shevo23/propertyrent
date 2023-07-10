using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BTLInmobiliaria
{
    public static class DataSetLinqOperators
    {
        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }

        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source,
                                DataTable table, LoadOption? options)
        {
            return new ObjectShredder<T>().Shred(source, table, options);
        }
    }

    public class ObjectShredder<T>
    {
        private FieldInfo[] _fi;
        private PropertyInfo[] _pi;
        private Dictionary<string, int> _ordinalMap;
        private Type _type;

        public ObjectShredder()
        {
            _type = typeof(T);
            _fi = _type.GetFields();
            _pi = _type.GetProperties();
            _ordinalMap = new Dictionary<string, int>();
        }

        public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            if (typeof(T).IsPrimitive)
            {
                return ShredPrimitive(source, table, options);
            }


            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            // now see if need to extend datatable base on the type T + build ordinal map
            table = ExtendTable(table, typeof(T));

            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (options != null)
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), true);
                    }
                }
            }
            table.EndLoadData();
            return table;
        }

        public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            if (!table.Columns.Contains("Value"))
            {
                table.Columns.Add("Value", typeof(T));
            }

            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                Object[] values = new object[table.Columns.Count];
                while (e.MoveNext())
                {
                    values[table.Columns["Value"].Ordinal] = e.Current;

                    if (options != null)
                    {
                        table.LoadDataRow(values, (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(values, true);
                    }
                }
            }
            table.EndLoadData();
            return table;
        }

        public DataTable ExtendTable(DataTable table, Type type)
        {
            foreach (FieldInfo f in type.GetFields())
            {
                if (!_ordinalMap.ContainsKey(f.Name))
                {
                    DataColumn dc = null;
                    //DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                    //    : table.Columns.Add(f.Name, f.FieldType);

                    if (table.Columns.Contains(f.Name))
                    {
                        dc = table.Columns[f.Name];
                    }
                    else
                    {
                        if (f.FieldType.Name != "Nullable`1")
                        {
                            table.Columns.Add(f.Name, f.FieldType);
                        }
                        else
                        {
                            string strCadena;
                            strCadena = f.FieldType.FullName.Substring(f.FieldType.FullName.IndexOf("[[") + 2).Substring(0, f.FieldType.FullName.Substring(f.FieldType.FullName.IndexOf("[[") + 2).IndexOf(",")).Trim();

                            switch (strCadena)
                            {
                                case "System.Int16":
                                    table.Columns.Add(f.Name, typeof(System.Int16));
                                    break;
                                case "System.Int32":
                                    table.Columns.Add(f.Name, typeof(System.Int32));
                                    break;
                                case "System.Int64":
                                    table.Columns.Add(f.Name, typeof(System.Int64));
                                    break;
                                case "System.UInt16":
                                    table.Columns.Add(f.Name, typeof(System.UInt16));
                                    break;
                                case "System.UInt32":
                                    table.Columns.Add(f.Name, typeof(System.UInt32));
                                    break;
                                case "System.UInt64":
                                    table.Columns.Add(f.Name, typeof(System.UInt64));
                                    break;
                                case "System.Char":
                                    table.Columns.Add(f.Name, typeof(System.Char));
                                    break;
                                case "System.Boolean":
                                    table.Columns.Add(f.Name, typeof(System.Boolean));
                                    break;
                                case "System.Decimal":
                                    table.Columns.Add(f.Name, typeof(System.Decimal));
                                    break;
                                case "System.DateTime":
                                    table.Columns.Add(f.Name, typeof(System.DateTime));
                                    break;
                                case "System.Double":
                                    table.Columns.Add(f.Name, typeof(System.Double));
                                    break;
                                case "System.Guid":
                                    table.Columns.Add(f.Name, typeof(System.Guid));
                                    break;
                                case "System.Object":
                                    table.Columns.Add(f.Name, typeof(System.Object));
                                    break;
                                case "System.Single":
                                    table.Columns.Add(f.Name, typeof(System.Single));
                                    break;
                                case "System.String":
                                    table.Columns.Add(f.Name, typeof(System.String));
                                    break;
                            }

                        }

                        dc = table.Columns[f.Name];

                    }

                    _ordinalMap.Add(f.Name, dc.Ordinal);


                }
            }
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (!_ordinalMap.ContainsKey(p.Name))
                {
                    DataColumn dc = null;

                    //DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                    //    : table.Columns.Add(p.Name, p.PropertyType);          

                    if (table.Columns.Contains(p.Name))
                    {
                        dc = table.Columns[p.Name];
                    }
                    else
                    {
                        if (p.PropertyType.Name != "Nullable`1")
                        {
                            table.Columns.Add(p.Name, p.PropertyType);
                        }
                        else
                        {
                            string strCadena;
                            strCadena = p.PropertyType.FullName.Substring(p.PropertyType.FullName.IndexOf("[[") + 2).Substring(0, p.PropertyType.FullName.Substring(p.PropertyType.FullName.IndexOf("[[") + 2).IndexOf(",")).Trim();

                            switch (strCadena)

                            {
                                case "System.Byte":
                                    table.Columns.Add(p.Name, typeof(System.Byte));
                                    break;

                                case "System.Int16":
                                    table.Columns.Add(p.Name, typeof(System.Int16));
                                    break;
                                case "System.Int32":
                                    table.Columns.Add(p.Name, typeof(System.Int32));
                                    break;
                                case "System.Int64":
                                    table.Columns.Add(p.Name, typeof(System.Int64));
                                    break;
                                case "System.UInt16":
                                    table.Columns.Add(p.Name, typeof(System.UInt16));
                                    break;
                                case "System.UInt32":
                                    table.Columns.Add(p.Name, typeof(System.UInt32));
                                    break;
                                case "System.UInt64":
                                    table.Columns.Add(p.Name, typeof(System.UInt64));
                                    break;
                                case "System.Char":
                                    table.Columns.Add(p.Name, typeof(System.Char));
                                    break;
                                case "System.Boolean":
                                    table.Columns.Add(p.Name, typeof(System.Boolean));
                                    break;
                                case "System.Decimal":
                                    table.Columns.Add(p.Name, typeof(System.Decimal));
                                    break;
                                case "System.DateTime":
                                    table.Columns.Add(p.Name, typeof(System.DateTime));
                                    break;
                                case "System.Double":
                                    table.Columns.Add(p.Name, typeof(System.Double));
                                    break;
                                case "System.Guid":
                                    table.Columns.Add(p.Name, typeof(System.Guid));
                                    break;
                                case "System.Object":
                                    table.Columns.Add(p.Name, typeof(System.Object));
                                    break;
                                case "System.Single":
                                    table.Columns.Add(p.Name, typeof(System.Single));
                                    break;
                                case "System.String":
                                    table.Columns.Add(p.Name, typeof(System.String));
                                    break;
                            }

                        }

                        dc = table.Columns[p.Name];

                    }
                    _ordinalMap.Add(p.Name, dc.Ordinal);
                }
            }
            return table;
        }

        public object[] ShredObject(DataTable table, T instance)
        {

            FieldInfo[] fi = _fi;
            PropertyInfo[] pi = _pi;

            if (instance.GetType() != typeof(T))
            {
                ExtendTable(table, instance.GetType());
                fi = instance.GetType().GetFields();
                pi = instance.GetType().GetProperties();
            }

            Object[] values = new object[table.Columns.Count];
            foreach (FieldInfo f in fi)
            {
                values[_ordinalMap[f.Name]] = f.GetValue(instance);
            }

            foreach (PropertyInfo p in pi)
            {
                values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
            }
            return values;
        }
    }
}