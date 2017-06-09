using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;


namespace TestJuniorWF
{
    public class MyList
    {
        MyItem header;
        List<MyItem> items;

        public MyList(string[] _rawList)
        {
            header = new MyItem(_rawList[0]);
            items = new List<MyItem>();

            for (int i = 1; i < _rawList.Length; i++)
            {
               items.Add(new MyItem(_rawList[i]));
            }
            for (int i = 1; i < items.Count; i++)
                if (items[i].ElementsNumber != header.ElementsNumber)
                    items.RemoveAt(i);


        }
        public MyItem Header
        {
            get { return header; }
        }
        public List<MyItem> Items
        {
            get { return items; }
        }

        public int ColumnsNumber
        {
            get { return header.ElementsNumber; }
        }

        public string ValueExamples(int _position)
        {
            string str = "";
            List <string> tempCollection = new List<string>();
            foreach (MyItem mi in items)
            {
                if ((tempCollection.Contains(mi.ItemsElement(_position))==false) && (mi.ItemsElement(_position)!=""))
                {
                    tempCollection.Add(mi.ItemsElement(_position));
                   
                }
                if (tempCollection.Count == 5) break;
            }
            if(tempCollection.Count<5)
            {
                for (int i = 0; i < tempCollection.Count-1; i++)
                    str = str + tempCollection[i] + " / ";
                str = str + tempCollection[tempCollection.Count-1];


            }
            else
            {
                for (int i = 0; i < 4; i++)
                    str = str + tempCollection[i] + " / ";
                str += "...";
            }

            return str;
        }

        public string IsEmptyItems(int _position)
        {
            for (int i = 0; i < items.Count; i++)
                if (items[i].ItemsElement(_position) == "")
                    return "There is at least one empty element";
            return "";
        }

        public string IsEmptyNonDigitsItems(int _position)
        {
            string s = "";
            List<string> temp = new List<string>();
            for (int i = 0; i < items.Count; i++)
                temp.Add(items[i].ItemsElement(_position).Replace('.', ','));
                double d;
            for (int i = 0; i < temp.Count; i++)
                if (Double.TryParse(temp[i], out d) == false)
                {
                    s = "There is at least one non-numeric element ";
                    break;
                }
            for (int i = 0; i < items.Count; i++)
                if (items[i].ItemsElement(_position) == "")
                {
                    s += "There is at least one empty element";
                    break;
                }

            return s;
        }

        public string IsNonDigitsItems(int _position)
        {

            List<string> temp = new List<string>();
            for (int i = 0; i < items.Count; i++)
                temp.Add(items[i].ItemsElement(_position).Replace('.', ','));
            double d;
            for (int i = 0; i < temp.Count; i++)
                if (Double.TryParse(temp[i], out d) == false)
                    return "There is at least one non-numeric element ";


            return "";
        }

        public bool IsPositionSumUniq(int _position1, int _position2)
        {
            List<string> tempCollection = new List<string>();
            foreach (MyItem mi in items)
            {
                if (tempCollection.Contains(mi.ItemsElement(_position1) + mi.ItemsElement(_position1)) == false)
                {
                    tempCollection.Add(mi.ItemsElement(_position1) + mi.ItemsElement(_position1));

                }
                else return true;
            }
                return false;
        }
        public string IsHeaderValid()
        {
            string tempString="";
            string[] headerArray= header.ToStringArray();
            foreach (string s in headerArray)
            {
                if (Regex.IsMatch(s, @"[^a-zA-Z\d_]")==true)
                {
                    tempString += " There is at least one name in header with invalid simbol.";
                    break;
                }
            }
            foreach (string s in headerArray)
            {
                if (String.IsNullOrEmpty(s) == true)
                {
                    tempString += " There is at least one empty name in header.";
                    break;
                }
            }
            for (int i = 0; i < headerArray.Length - 1; i++)
                for(int k = i + 1; k < headerArray.Length; k++)
                    if(headerArray[i]==headerArray[k])
                    {
                        tempString += " There is at least one doubled name in header.";
                        break;
                    }


            return tempString;
        }
    }
}
