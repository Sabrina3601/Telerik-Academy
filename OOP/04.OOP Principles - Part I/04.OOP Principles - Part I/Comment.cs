using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OOP_Principles___Part_I
{
    public class Comment
    {
        public List<string> Comments { get; set; }

        public Comment()
        {
            this.Comments = new List<string>();
        }

        //add comment
        public void AddComment(string comment)
        {
            bool exist = this.Comments.Contains(comment);

            if (!exist)
            {
                this.Comments.Add(comment);
            }
        }

        // remove comment
        public void RemoveComment(string comment)
        {
            bool exist = this.Comments.Contains(comment);

            if (exist)
            {
                this.Comments.Remove(comment);
            }
        }

        // clear all comments
        public void ClearAllComments()
        {
            this.Comments.Clear();
        }

        // print all comments
        public void ShowComment()
        {
            if (Comments.Count == 0)
            {
                Console.WriteLine("No comments");
            }
            else
            {
                foreach (var comment in Comments)
                {
                    Console.WriteLine(comment);
                }
            }           
        }
    }
}
