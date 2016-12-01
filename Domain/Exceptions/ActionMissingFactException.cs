using System;

public class ActionMissingFactException : Exception
{
    public ActionMissingFactException()
    {

    }

    public ActionMissingFactException(string exception) : base(exception)
    {

    }
}