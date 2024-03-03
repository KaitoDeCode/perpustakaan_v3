using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perpustakaan_v3
{
    internal class utils
    {
        public bool checkEmpty(params String[] values )
        {
            foreach (var item in values)
            {
                if (item == "" || item=="0" || item==null || item==" ")
                {
                    msg("err","Inputan tidak boleh kosong atau bernilai 0");
                    return true;
                    break;
                }
            }
                return false;
        }

        public void msg(String status,String msg)
        {
            if (status == "scs") MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (status == "err") MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
