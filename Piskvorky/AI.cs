using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piskvorky 
{
    class AI
    {
        //PoleForm poleForm = new PoleForm();
        bool vyplneno = false;
        Random random = new Random();
        int randomX;
        int randomY;
        //string[,] znaky;
        public AI()
        {
            
        }
        public void Lehky(string[,] znaky, ref int x, ref int y)
        {
            vyplneno = false;
            while (vyplneno == false)
            {
                
                randomX = random.Next(0, PoleForm.velikostPole);
                randomY = random.Next(0, PoleForm.velikostPole);
                if (znaky[randomX, randomY] == "")
                {
                    x = randomX;
                    y = randomY;                    
                    vyplneno = true;                    
                }
                
            } 
        }
        
    }
}
