using System.Text;
using System.Diagnostics;
using UnityEngine;

namespace CommandTerminal
{
    public static class MyCommands
    {
		[RegisterCommand(Name = "Lang")]
		static void ChangeLanguage(CommandArg[] args)
		{
			Wokarol.LocalizationManager.Instance.ChangeLanguage(args[0].String);
		}
    }
}
