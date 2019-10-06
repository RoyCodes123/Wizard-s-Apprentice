using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigNum
{
    class BigNum
    {
        private int[] num;

        public BigNum(string str) {
            this.num = new int[20];
            for (int i = this.num.Length - 1; i >= 0; i--) {
                this.num[i] = str[i] - 48;
            }
        }

        public BigNum()
        {
            this.num = new int[20];
            for (int i = this.num.Length - 1; i >= 0; i--)
            {
                this.num[i] = 0;
            }
        }

        public bool IsEqual(BigNum num1) {
            for (int i = 0; i < this.num.Length; i++) {
                if (this.num[i] != num1.num[i]) {
                    return false;
                }
            }
            return true;
        }

        public BigNum Addition(BigNum num1) {
            BigNum newNum = new BigNum();
            for (int i = this.num.Length - 1; i >= 0; i--) {
                if (num1.num[i] + this.num[i] >= 10)
                {
                    newNum.num[i - 1]++;
                    newNum.num[i] += num1.num[i] + this.num[i] - 10;
                }

                else { newNum.num[i] += num1.num[i] + this.num[i]; }

                if (i == 0) {
                    if (num1.num[i] + this.num[i] >= 10) {
                        return null;
                    }
                }
            }
            return newNum;
        }

        public BigNum Multiplication(BigNum num1)
        {
            BigNum count = new BigNum();
            BigNum add = new BigNum("00000000000000000001");
            BigNum newNum = new BigNum();
            while (!(count.IsEqual(num1)))
            {
                newNum = newNum.Addition(this);
                count = count.Addition(add);
            }
            return newNum;
        }

        public override string ToString() {
            string str = "";
            for (int i = 0; i < this.num.Length; i++) {
                str += this.num[i];
            }
            return str;
        }
    }
}
