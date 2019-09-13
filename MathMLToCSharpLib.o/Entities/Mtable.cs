using System.Text;

namespace MathMLToCSharpLib.Entities
{
    /// <summary>
    /// A table. Typically used for matrices.
    /// </summary>
    public class Mtable : WithBuildableContents
    {
        static int level = 0;
        public Mtable() { }
        public Mtable(IBuildable[] contents) : base(contents) { }
        public override void Visit(StringBuilder sb, BuildContext context)
        {
            level++;
            if (level == 1)
                sb.Append("DenseMatrix.OfArray(new double[,] {");//matrix
            else
                sb.Append("{");//matrix
            for (int i = 0; i < contents.Length; ++i)
            {
                contents[i].Visit(sb, context);
                if (i + 1 != contents.Length)
                    sb.Append(", ");
            }
            if (level == 1)
                sb.Append("})");
            else
                sb.Append("}");
            level--;
        }
    }
}