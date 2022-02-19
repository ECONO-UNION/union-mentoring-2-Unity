using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class CommandManager : MonoBehaviour
{
    private static CommandManager instance;

    public static CommandManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<CommandManager>();

            return instance;
        }
    }

    private Stack<ICommand> CommandsBuffer = new Stack<ICommand>();


    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static ICommand CreateCommand(CommandType commandType)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        System.Type t = assembly.GetType(commandType.ToString() + "Command");
        object obj = System.Activator.CreateInstance(t);
        return (ICommand)obj;
    }

    public void AddCommand(CommandType commandType)
    {
        ICommand cmd = CreateCommand(commandType);
        if (cmd != null)
        {
            cmd.Execute();
            CommandsBuffer.Push(cmd);
        }
    }
}
