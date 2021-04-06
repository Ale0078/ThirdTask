namespace ThirdTask.Validators
{
    public class TriangleValidator
    {
        public bool IsTriangle(params double[] triangleSides) 
        {
            if (((triangleSides[0] + triangleSides[1]) > triangleSides[2])
                && ((triangleSides[2] + triangleSides[1]) > triangleSides[0])
                && ((triangleSides[0] + triangleSides[2]) > triangleSides[1])) 
            {
                return true;
            }

            return false;
        }
    }
}
