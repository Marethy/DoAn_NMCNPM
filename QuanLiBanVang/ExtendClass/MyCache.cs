using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLiBanVang.ExtendClass
{
    class MyCache
    {
        private readonly string _keyFieldName;
        Dictionary<object, object> _valueCache = new Dictionary<object, object>();
        public MyCache(string keyfieldname)
        {
            _keyFieldName = keyfieldname;
        }
        public object getKeyByRow(object row)
        {
            return (row as DataRowView)[_keyFieldName];
        }
        public object getValueByKey(object key)
        {
            object result = null;
            _valueCache.TryGetValue(key, out result);
            return result;
        }
        public object getValue(object row)
        {
            return getValueByKey(getKeyByRow(row));
        }
        public void setValue(object row, object value)
        {
            setValueByKey(getKeyByRow(row), value);
        }
        public void setValueByKey(object key, object value)
        {
            _valueCache[key] = value;
        }

    }
}
