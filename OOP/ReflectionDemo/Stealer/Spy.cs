using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        var targetType = Type.GetType(className);
        var fields = targetType.GetFields(BindingFlags.Instance | BindingFlags.Public);
        var publicMethods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var nonPublicMethods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var hacker = Activator.CreateInstance(targetType, new object[] { });

        var finalStringBuild = new StringBuilder();
        foreach (var field in fields)
        {
            finalStringBuild.AppendLine($"{field.Name} must be private!");
        }  
        foreach (var nonPMethods in nonPublicMethods.Where(x=> x.Name.StartsWith("get")))
        {
            finalStringBuild.AppendLine($"{nonPMethods.Name} have to be public!");
        }
        foreach (var pmethod in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            finalStringBuild.AppendLine($"{pmethod.Name} have to be private!");
        }
        return finalStringBuild.ToString().TrimEnd();
    }
    public string StealFieldInfo(string hackerName, params string[] targetFields)
    {
        var targetType = Type.GetType(hackerName);
        var hackerFields = targetType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        var hacker = Activator.CreateInstance(targetType, new object[] { });
        var finalString = new StringBuilder();
        finalString.AppendLine($"Class under investigation: {targetType}");
        foreach (var field in hackerFields.Where(x => targetFields.Contains(x.Name)))
        {
            var fieldValue = field.GetValue(hacker);
            finalString.AppendLine($"{field.Name} = {fieldValue}");
        }
        return finalString.ToString().TrimEnd();
    }
}

