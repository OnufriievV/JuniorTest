using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJuniorWF
{
    public class MyListDB
    {
        MyItem header;
        MyItem parameters;
        List<MyItem> items;
        int positionPrice;
        int positionWeight;
        public MyListDB (MyList _myList, List<string> _parameters)
        {
            parameters = new MyItem(_parameters);
            header = _myList.Header;
            items = _myList.Items;
            for (int i = parameters.ElementsNumber - 1; i >= 0; i--)
            {
                if (parameters.ItemsElement(i) == "Ignore")
                    this.RemoveInClassAtPosition(i);
            }

        }

        void RemoveInClassAtPosition(int _position)
        {
            for (int i = 0; i < items.Count; i++)
                items[i].RemoveElement(_position);
            header.RemoveElement(_position);
            parameters.RemoveElement(_position);
        }

        public string StringCreateTable()
        {
            int productParameterCount = 1;
            int featureCount = 1;
            string tempString = "CREATE TABLE [dbo].[Products] (";
            for (int i = 0; i < parameters.ElementsNumber; i++)
            {
                switch (parameters.ItemsElement(i))
                {
                    case "SKU":
                        {
                            tempString+= "[SKU] NVARCHAR(100) NOT NULL, ";
                            break;
                        }
                    case "Brand":
                        {
                            tempString += "[Brand] NVARCHAR(100) NOT NULL, ";
                            break;
                        }
                    case "Price":
                        {
                            tempString += "[Price] FLOAT NOT NULL, ";
                            positionPrice = i;
                            break;
                        }
                    case "Weight":
                        {
                            tempString += "[Weight] FLOAT NULL, ";
                            positionWeight = i;
                            break;
                        }
                    case "Feature":
                        {
                            tempString += "[Feature" + featureCount + "] NVARCHAR(MAX) NULL, ";
                            featureCount++;
                            break;
                        }
                    
                    case "Product parameter":
                        {
                            tempString += "[Product parameter" + productParameterCount + "] NVARCHAR(MAX) NULL, ";
                            productParameterCount++;
                            break;
                        }
                    

                }

            }
            tempString = tempString.TrimEnd(' ', ',');
            tempString += "); alter table [Products] add constraint PK primary key (SKU, Brand);";
            return tempString;
        }

        public string StringFillDB(int _position)
        {
            string tempString = "INSERT INTO Products VALUES";
           
                tempString += " (";
                for (int k = 0; k < items[_position].ElementsNumber; k++)
                {
                    if ((k == positionPrice) || (k == positionWeight))
                    {
                        tempString = tempString  + items[_position].ItemsElement(k)+ ", ";
                    }
                    else
                    {
                        tempString = tempString  + "'" + items[_position].ItemsElement(k) + "'"+ ", ";
                    }

                }
            tempString = tempString.TrimEnd(',', ' ');
            tempString += ");";
            
            return tempString;
        }

        public int ItemsNumber
        {
            get { return items.Count;}
        }
        public MyItem Header
        {
            get { return header; }
        }
    }
}
