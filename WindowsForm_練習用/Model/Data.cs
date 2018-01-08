using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm_練習用.Model
{
    class Data
    {
        // コンストラクタ
        public Data()
        {
            for (int i=0; i<100; i++)
            {
                comboBoxDataList.Add(new ComboBoxData());
            }
        }

        // Data
        public List<ComboBoxData> comboBoxDataList = new List<ComboBoxData>();
    }

    class ComboBoxData
    {
        //コンストラクタ
        public ComboBoxData()
        {
            ComboBoxChoices = ComboBoxChoices.data1;
        }

        // Data
        public ComboBoxChoices ComboBoxChoices { get; set; }
    }

    enum ComboBoxChoices
    {
        data1,
        data2,
    }
}
