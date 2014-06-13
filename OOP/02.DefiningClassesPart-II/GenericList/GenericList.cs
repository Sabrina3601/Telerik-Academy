//Task 5
//Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
//Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
//Implement methods for adding element, accessing element by index,
//removing element by index, inserting element at given position, clearing the list,
//finding element by its value and ToString(). 
//Check all input parameters to avoid accessing elements at invalid positions.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList<T>
    {
        const int DefaultCapacity = 16;
        private T[] elements;
        private int count = 0;

        public int Count
        {
            get { return this.count; }//getter
        }

        // constructor without parametars
        public GenericList()
        {
            elements = new T[DefaultCapacity];
        }

        //constructor with parametars
        public GenericList(int capacity)
        {
            if (capacity >= 0)
            {
                elements = new T[capacity];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can't be negative index");
            }
        }      
        
        //Add method
        public void Add(T element)
        {
            if (count >= elements.Length )
            {
                throw new ArgumentOutOfRangeException(String.Format("This list capacity of {0} was exceeded.", elements.Length));
            }
            this.elements[count] = element;
            count++;
        }

        //add Remove method
        public void Remove(int index)
        {
            if (index >= elements.Count() || index <= 0)
            {
                throw new ArgumentOutOfRangeException(String.Format("This list capacity of {0} was exceeded.", elements.Length));
            }
            T[] newElements = new T[elements.Count() - 1];
            for (int i = 0; i < newElements.Length; i++)
            {
                if (index == i)
                {
                    i++;
                }
                else
                {
                    newElements[i] = elements[i];
                }
            }

        }

        //accesing elements by index
        public T this[int index]
        {
            get
            {
                if (index >= count || index <=0)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index {0}", index));
                }
                return elements[index];
            }
            set
            {
                if (index >= count|| index <= 0)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index {0}", index));
                }
                elements[index] = value;
            }
        }

        //inseting element at given position
        public void InsetElement(int index, T element)
        {
            if (index >= count || index <= 0)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index {0}", index));
            }
            T[] newElements = new T[this.Count+1];
           int iter = 0;
           for (int i = 0; i < newElements.Count(); i++)
           {
               if (i == index)
               {
                   newElements[i] = element;
               }
               else
               {
                   newElements[i] = elements[iter];
                   iter++;
               }
           }
           elements  = new T[this.Count + 1];
           elements = newElements;
        }

        //clear the list
        public void Clear()
        {
            elements = new T[0];
            count = 0;
        }


        public override String ToString()
        {
            T[] temp = new T[Count];
            Array.Copy(elements, temp, Count);
            return String.Join(", ", temp);
        }

        //Task6
        //Implement auto-grow functionality: 
        //when the internal array is full, create a new array of double size and move all elements to it.
        public void ExpandArray()
        {
            T[] tempArr = new T[count * 2];
            Array.Copy(elements, tempArr, Count);
            elements = tempArr;
        }

        //Task 7
        //Create generic methods Min<T>() and Max<T>() 
        //for finding the minimal and maximal element in the  GenericList<T>.
        //You may need to add a generic constraints for the type T.

        //Add min Mehtod
        public T Min()
        {
            if (count ==0)
            {
                throw new Exception("Is empty lïst");
            }
            else
            {
                T min = elements[0];
                for (int i = 1; i < elements.Count(); i++)
                {
                    if ((min as IComparable<T>).CompareTo(elements[i]) > 0 )
                    {
                        min = elements[i];
                    }
                }
                return min;
            }
        }

        //Add Max Method
        public T Max()
        {
            if (count == 0)
            {
                throw new Exception("Is empty list");
            }
            else
            {
                T max = elements[0];
                for (int i = 1; i < elements.Count(); i++)
                {
                    if ((max as IComparable<T>).CompareTo(elements[i]) < 0)
                    {
                        max = elements[i];
                    }
                }
                return max;
            }
        }
    }
}
