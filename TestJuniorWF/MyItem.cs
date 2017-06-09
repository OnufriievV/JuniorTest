using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJuniorWF
{
    public class MyItem
    {
        List<string> item;
        public MyItem(string _rawItem)
        {
            item = new List<string>();
            string[] rawItem = _rawItem.Split(',');
            for (int i = 0; i < rawItem.Length; i++)
            {
                item.Add(rawItem[i]);
            }
        }
        public MyItem(List<string> _rawListItem)
        {
            item = new List<string>();
            foreach (string s in _rawListItem)
                item.Add(s);
        }
        public string[] ToStringArray()
        {
            return item.ToArray();
        }
        public int ElementsNumber
        {
            get { return item.Count; }
        }

        public string ItemsElement(int _position)
        {
            return item[_position];
        }

        public void ItemsElementReplace(int _position, string _string)
        {
             item[_position] = _string;
        }

        public void RemoveElement(int _position)
        {
            item.RemoveAt(_position);
        }

        //public string ItemsToStringForDB(int _position)
        //{
        //    string tempString = "(DEFAULT,
        //}
    }
    
}
