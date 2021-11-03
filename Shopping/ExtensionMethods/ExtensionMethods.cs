using Shopping.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.ExtensionMethods
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns an identical copy
        /// </summary>
        /// <param name="listToClone"></param>
        /// <returns></returns>
        public static List<string> Clone(this List<string> listToClone)
        {
            return listToClone.ToList();
        }

        /// <summary>
        /// Returns true if all items in 'containsElements' are in the list, and allows for duplicates
        /// </summary>
        /// <param name="list"></param>
        /// <param name="containsElements"></param>
        /// <returns></returns>
        public static bool ContainsAllItems(this List<string> list, List<string> containsElements)
        {
            // Take a copy of the list, as we need to remove elements as we compare to cater for duplicates
            // ** This may become inefficient for large lists **
            var workingList = list.Clone();

            foreach (var element in containsElements)
            {
                if (workingList.Contains(element))
                {
                    workingList.Remove(element);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Removes all items that exist in "removeElements", allowing for duplicates
        /// </summary>
        /// <param name="list"></param>
        /// <param name="removeElements"></param>
        /// <returns></returns>
        public static bool RemoveAllItems(this List<string> list, List<string> removeElements)
        {
            foreach (var element in removeElements)
            {
                if (list.Contains(element))
                {
                    list.Remove(element);
                }
            }

            return true;
        }
    }
}
