namespace MyApp;

public class DecisionResult : Decision
{
    private string res;

    public DecisionResult(string res)
    {
        this.res = res;
    }
    public override string Evaluate(IEntity entity)
    {
       return(res);
    }
}