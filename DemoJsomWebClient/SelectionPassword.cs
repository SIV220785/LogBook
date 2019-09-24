using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJsomWebClient
{
    public class SelectionPassword
    {
        List<char> _tempPassword;
        List<char> _lettes;
        List<int> _count;
        string _exitConditions;

        public SelectionPassword()
        {
            _tempPassword = new List<char>() { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' };
            _lettes = new List<char>() { 'a', 'A', '1' };
            _count = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            _exitConditions = "1111111111";

        }

        public void SelectionPass(ref string password, ref bool isCheck)
        {

            if (password.Equals(_exitConditions))
            {
                isCheck = false;
            }

            for (int i = _count.Count() - 1; i > -1; i--)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (_count[i] == j)
                    {
                        ++_count[i];

                        break;
                    }
                }

                if (_count[i] == 3)
                {
                    ++_count[i - 1];
                    _count[i] = 0;
                    break;
                }

                if (_count[i] != 0)
                {
                    break;
                }
            }

            for (int i = _count.Count() - 1; i > -1; i--)
            {
                if (_count[i] == 3)
                {
                    if (_count[0] == 3)
                    {
                        isCheck = false;
                        return;
                    }
                    _count[i] = 0;
                    ++_count[i - 1];
                    _tempPassword[i] = _lettes[_count[i]];
                }
            }

            var temp = "";
            foreach (var item in _count)
            {
                temp += item;
            }

            try
            {
                for (int i = 0; i < _tempPassword.Count(); i++)
                {
                    _tempPassword[i] = _lettes[_count[i]];
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            

            var tempPas = "";

            foreach (var item in _tempPassword)
            {
                tempPas += item;
            }
            password = tempPas;

        }
    }
}
