using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace WebApplication3
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //First item in the drop down is 2 players but is at index 0
            if (!int.TryParse(NumberOfPlayersTextBox.Text, out int NumberOfPlayers))
            {
                return;
            }
            //Get the number of minutes
            if (!int.TryParse(MinutesPlayedTextBox.Text, out int NumberOfTimeUnits))
            {
                return;
            }
            //Mode of play. I could have gotten the value and swiched on that but meh.
            int ModeOfPlay = ModeDropDownList.SelectedIndex;
            int[] XP = XPCalc(NumberOfPlayers, NumberOfTimeUnits,ModeOfPlay);
            string NewContentForTextBox = "";

            switch (ModeOfPlay)
            {

                //Mode 0: Ranked Play
                case 0:
                    for (int n = 0; n < XP.Length; ++n)
                    {
                        NewContentForTextBox += $"{AddOrdinal(n + 1)} Place: {XP[n]}{Environment.NewLine}";
                    }
                    break;

                //Mode 1: Co - Op, Party, Teams
                default:
                    NewContentForTextBox = $"Winners: {XP[0] } XP{Environment.NewLine}Losers {XP[1]}";   
                    break;


            }

            //Write the content to the textbox
            TextBox1.Text = NewContentForTextBox;
            //Try to log the file (if it fails it's not a big deal)
            try
            {
                File.AppendAllText(@"C:\home\site\wwwroot\Logs.txt", $"{NumberOfPlayers},{NumberOfTimeUnits},{ModeOfPlay}{Environment.NewLine}");
            }
            catch (IOException)
            {
                //ignore
            }
        }

        protected string AddOrdinal(int num)
        {
            //Nope, not even bothering with negatives. Fuck that shit I'm out.
            if (num <= 0)
            {
                return num.ToString();
            }

            //11, 12, and 13 are weird, so we check for them first
            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            //Otherwise we just check the last digit
            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }


  

        protected int[] XPCalc(int Players, int Time, int Mode)
        {
            const int rankedPositions = 5;
            const double points = 1.5;//scale of points awarded (makes numbers bigger bc big numbers are fun)
            const double xtra = points/2;//xtra is points/(n-1) where 1/n = fraction of points based off bonus 
            int[] XPList = new int[Players];

            double basePoints = points * Time;
            switch (Mode){
                
                //Ranked plays
                case 0:
                    if (Players >= rankedPositions)
                    {
                        for (int i = 0; i < Players && i < rankedPositions; i++)
                        {
                            XPList[i] = (int)(basePoints + (xtra * Time) / (i + 1));
                        }
                        for (int i = rankedPositions; i < Players; i++)
                        {
                            XPList[i] = (int)(basePoints);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Players && i < rankedPositions; i++)
                        {
                            XPList[i] = (int)(basePoints + (xtra * Time) / (i + 1 + rankedPositions- Players));
                        }
                    }
                    break;

                    //Co-op, Party, Teams
                default://winning gets 2nd/3rdish then loosers get base points
                    //XPList[0] = points for winners
                    XPList[0] = (int)((basePoints + (xtra * Time)/2));//equivalent to 2nd place in a ranked game

                    //XPList[1] = points for losers
                    XPList[1] = (int)(basePoints);
                    break;

            }

            return XPList;
        }
        
    }
}