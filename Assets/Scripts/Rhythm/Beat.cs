public class Beat
{
    public int time { get; set; }
    public float xPos { get; set; }

    public Beat(int time, float xPos)
    {
        this.time = time;
        this.xPos = xPos;
    }
}