using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.ControlesFactura
{
    public class ComponentesFactura
    {
        public static Font bold2 = new Font("Courier", 9, FontStyle.Italic);
        public static Font bold = new Font("Courier", 10, FontStyle.Bold);
        public static Font boldReg = new Font("Courier", 10, FontStyle.Regular);
        public static Font bold3 = new Font("Courier", 9, FontStyle.Bold);
        public static Font bold1 = new Font("Courier", 9, FontStyle.Regular);
        public static Font regular = new Font("Courier", 9, FontStyle.Bold);
        public static Font regularItens = new Font("Courier", 7, FontStyle.Regular);
        public static Font regularItens2 = new Font("Courier", 8, FontStyle.Regular);
        public static Font regularItens3 = new Font("Courier", 9, FontStyle.Regular | FontStyle.Bold);
        public static Pen minhaPen1 = new Pen(Color.Black, 1);
        public static Pen minhaPen3 = new Pen(Color.White, 1);
        public static Pen minhaPen2 = new Pen(Color.Black, 2);
        public static Rectangle rect = new Rectangle(35, 105, 200, 50);//220
        public static RectangleF rect1 = new RectangleF(35, 110, 200, 50);
        public static string NomeFuncionarioActivo;
    }
}
