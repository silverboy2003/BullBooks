﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Data;
using System.Reflection;

namespace BL
{
    public class Thread
    {
        private int threadID;
        private string threadTitle;
        private string threadText;
        private int threadBookID;
        private string threadBook;
        private int threadAuthorID;
        private string threadAuthor;
        private int cntComments;
        private DateTime creationDate;
        private List<Comment> threadMasterComments; //every comment contains it's replies, so this list only contains the comments that reply directly to the thread 
        public Thread(int threadID, string threadTitle, string threadText, int threadBookID, string threadBook, int threadAuthorID, string threadAuthor, int cntComments, DateTime creationDate, List<Comment> threadComments)
        {
            this.threadID = threadID;
            this.threadTitle = threadTitle;
            this.threadText = threadText;
            this.threadBookID = threadBookID;
            this.threadBook = threadBook;
            this.threadAuthorID = threadAuthorID;
            this.threadAuthor = threadAuthor;
            this.cntComments = cntComments;
            this.creationDate = creationDate;
            this.threadMasterComments = threadComments;
        }
        public Thread(DataRow thread)//need to load seperately cntcomments and threadcomments
        {
            this.threadID = (int)thread["threadID"];
            this.threadTitle = (string)thread["threadTitle"];
            this.threadText = (string)thread["threadText"];
            this.threadBookID = (int)thread["threadBookID"];
            this.threadAuthorID = (int)thread["threadAuthorID"];
            this.creationDate = (DateTime)thread["threadDate"];
            this.threadBook = (string)thread["threadBook"];
            this.threadAuthor = (string)thread["threadAuthor"];
            threadMasterComments = new List<Comment>();
        }

        public int ThreadID { get => threadID; set => threadID = value; }
        public string ThreadTitle { get => threadTitle; set => threadTitle = value; }
        public string ThreadText { get => threadText; set => threadText = value; }
        public int ThreadBookID { get => threadBookID; set => threadBookID = value; }
        public string ThreadBook { get => threadBook; set => threadBook = value; }
        public int ThreadAuthorID { get => threadAuthorID; set => threadAuthorID = value; }
        public string ThreadAuthor { get => threadAuthor; set => threadAuthor = value; }
        public int CntComments { get => cntComments; set => cntComments = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public List<Comment> ThreadMasterComments { get => threadMasterComments; set => threadMasterComments = value; }

        public static Dictionary<int, Thread> GetAllThreads()
        {
            DataTable threads = DAL.ThreadHelper.GetAllThreads();
            Dictionary<int, Thread> ThreadList = new Dictionary<int, Thread>();
            foreach(DataRow thread in threads.Rows)
            {
                Thread newThread = new Thread(thread);
                ThreadList.Add(newThread.threadID, newThread);
            }
            return ThreadList;
        }
    }
}