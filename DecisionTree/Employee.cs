using DecisionTree.Models;

namespace MyApp;

public class Employee :IEntity
{
    public QuestionModel model;
    public bool getAnswer(string title)
    {
        if (title == "Employee answered to the Call?")
        {
            return model.question1;
        }
        
        if(title == "Does he have a good CV?")
        {
            return model.question2;
        }
        
        if (title == "Is he go to interview?")
        {
            return model.question3;
        }

        if (title == "Do you have a success interview?")
        {
            return model.question4;
        }

        if (title=="Does he have required documents?")
        {
            return model.question5;
        }

        if (title=="Has he gone on the first day?")
        {
            return model.question6;
        }
        return true;
    }
}