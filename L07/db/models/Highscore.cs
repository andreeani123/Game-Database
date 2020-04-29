using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07.db.models
{
    class Highscore
    {
        private long id;
        private string gamer;
        private int hscore;

        public long Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }

        public string Gamer
        {
            set
            {
                gamer = value;
            }
            get
            {
                return gamer;
            }
        }

        public int Hscore
        {
            set
            {
                hscore = value;
            }
            get
            {
                return hscore;
            }
        }

        public override string ToString()
        {
            return "{ id: " + id + ", gamer: \"" + gamer + "\", highscore: " + hscore + " }";
        }
    }
}
