using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    int r1, r2, num, userscore,dealerscore=0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Game(string mode)
    {
        Random random = new Random();
        switch (mode)
        {
            case "Deal":               
                Play_lbl.Visible = false;
                r1 = random.Next(1, 11);
                r2 = random.Next(1, 11);
                Player_Card.Text =Convert.ToString(r1);
                Player_Card2.Text =Convert.ToString(r2);
                CardPanel.Visible = true;
                Player_Card.Visible = true;
                Player_Card2.Visible = true;                           
                ScoreUser.Text = Convert.ToString(r1+r2);                
                ScorePanel.Visible = true;
                Deal_btn.Enabled = false;
                break;

            case "Hit":
                num = random.Next(1, 11);
                Player_Card.Text = Convert.ToString(num);
                Player_Card2.Visible = false;
                userscore = (Convert.ToInt16(ScoreUser.Text))+(Convert.ToInt16(Player_Card.Text));
                ScoreUser.Text = Convert.ToString(userscore);
                if (userscore > 21)
                {
                    Result_Label.Text = "You lost!";
                    Result_Label.Visible = true;
                    Replay();                  
                }
                break;
            case "Pass":                          
                while (dealerscore < 17)
                {
                    dealerscore = dealerscore+random.Next(1, 11);
                    
                }
                if(dealerscore>21)
                {
                    ScoreDealer.Text = Convert.ToString(dealerscore);
                    ScoreDealer.Visible = true;
                    Result_Label.Text = "You won!";
                    Result_Label.Visible = true;
                }
                else
                {
                    ScoreDealer.Text = Convert.ToString(dealerscore);
                    ScoreDealer.Visible = true;
                    if (userscore > dealerscore)
                    {
                        Result_Label.Text = "You won!";
                        Result_Label.Visible = true;
                    }
                    else if (userscore < dealerscore)
                    {
                        Result_Label.Text = "You lost!";
                        Result_Label.Visible = true;
                    }
                    else
                    {
                        Result_Label.Text = "It's a tie!";
                        Result_Label.Visible = true;
                    }
                }
                Replay();
                break;
            case "End":
                Restart();
                break;
        }
    }

    public void Restart()
    {
        ScorePanel.Visible = false;
        CardPanel.Visible = false;
        dealerscore = 0;
        ScoreDealer.Visible = false;
        Result_Label.Visible = false;
        Play_lbl.Visible = true;
        ButtonPanel.Visible = true;
        Deal_btn.Enabled = true;
        Replay_btn.Visible = false;
    }
    public void Replay()
    {
        Play_lbl.Text = "Click to play again!";
        Replay_btn.Visible = true;
        ButtonPanel.Visible = false;
    }



    protected void Deal_btn_Click(object sender, EventArgs e)
    {
        Game("Deal");
    }

    protected void Hit_btn_Click(object sender, EventArgs e)
    {
        Game("Hit");        
    }

    protected void Pass_btn_Click(object sender, EventArgs e)
    {
        Game("Pass");
    }

    protected void End_btn_Click(object sender, EventArgs e)
    {
        Game("End");
    }

    protected void Replay_btn_Click(object sender, EventArgs e)
    {
        Restart();
    }
}