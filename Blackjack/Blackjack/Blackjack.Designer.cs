namespace Blackjack
{
    partial class Blackjack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstCard = new System.Windows.Forms.Label();
            this.secondCard = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.hitButton = new System.Windows.Forms.Button();
            this.dealerTotalLabel = new System.Windows.Forms.Label();
            this.firstDealerCard = new System.Windows.Forms.Label();
            this.secondDealerCard = new System.Windows.Forms.Label();
            this.stayButton = new System.Windows.Forms.Button();
            this.aceLabel = new System.Windows.Forms.Label();
            this.deckLabel = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.lossLabel = new System.Windows.Forms.Label();
            this.WLRLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstCard
            // 
            this.firstCard.AutoSize = true;
            this.firstCard.Location = new System.Drawing.Point(12, 127);
            this.firstCard.Name = "firstCard";
            this.firstCard.Size = new System.Drawing.Size(19, 13);
            this.firstCard.TabIndex = 0;
            this.firstCard.Text = "10";
            // 
            // secondCard
            // 
            this.secondCard.AutoSize = true;
            this.secondCard.Location = new System.Drawing.Point(37, 127);
            this.secondCard.Name = "secondCard";
            this.secondCard.Size = new System.Drawing.Size(19, 13);
            this.secondCard.TabIndex = 1;
            this.secondCard.Text = "10";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(12, 103);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(49, 13);
            this.totalLabel.TabIndex = 2;
            this.totalLabel.Text = "Total: 10";
            // 
            // hitButton
            // 
            this.hitButton.Location = new System.Drawing.Point(15, 185);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(75, 23);
            this.hitButton.TabIndex = 3;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // dealerTotalLabel
            // 
            this.dealerTotalLabel.AutoSize = true;
            this.dealerTotalLabel.Location = new System.Drawing.Point(12, 44);
            this.dealerTotalLabel.Name = "dealerTotalLabel";
            this.dealerTotalLabel.Size = new System.Drawing.Size(83, 13);
            this.dealerTotalLabel.TabIndex = 4;
            this.dealerTotalLabel.Text = "Dealer Total: 10";
            // 
            // firstDealerCard
            // 
            this.firstDealerCard.AutoSize = true;
            this.firstDealerCard.Location = new System.Drawing.Point(12, 68);
            this.firstDealerCard.Name = "firstDealerCard";
            this.firstDealerCard.Size = new System.Drawing.Size(19, 13);
            this.firstDealerCard.TabIndex = 5;
            this.firstDealerCard.Text = "10";
            this.firstDealerCard.Visible = false;
            // 
            // secondDealerCard
            // 
            this.secondDealerCard.AutoSize = true;
            this.secondDealerCard.Location = new System.Drawing.Point(37, 68);
            this.secondDealerCard.Name = "secondDealerCard";
            this.secondDealerCard.Size = new System.Drawing.Size(19, 13);
            this.secondDealerCard.TabIndex = 6;
            this.secondDealerCard.Text = "10";
            // 
            // stayButton
            // 
            this.stayButton.Location = new System.Drawing.Point(126, 185);
            this.stayButton.Name = "stayButton";
            this.stayButton.Size = new System.Drawing.Size(75, 23);
            this.stayButton.TabIndex = 7;
            this.stayButton.Text = "Stay";
            this.stayButton.UseVisualStyleBackColor = true;
            this.stayButton.Click += new System.EventHandler(this.stayButton_Click);
            // 
            // aceLabel
            // 
            this.aceLabel.AutoSize = true;
            this.aceLabel.Location = new System.Drawing.Point(12, 153);
            this.aceLabel.Name = "aceLabel";
            this.aceLabel.Size = new System.Drawing.Size(0, 13);
            this.aceLabel.TabIndex = 8;
            // 
            // deckLabel
            // 
            this.deckLabel.AutoSize = true;
            this.deckLabel.Location = new System.Drawing.Point(12, 11);
            this.deckLabel.Name = "deckLabel";
            this.deckLabel.Size = new System.Drawing.Size(92, 13);
            this.deckLabel.TabIndex = 9;
            this.deckLabel.Text = "Cards in Deck: 52";
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Location = new System.Drawing.Point(135, 52);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(43, 13);
            this.winLabel.TabIndex = 10;
            this.winLabel.Text = "Wins: 0";
            // 
            // lossLabel
            // 
            this.lossLabel.AutoSize = true;
            this.lossLabel.Location = new System.Drawing.Point(135, 77);
            this.lossLabel.Name = "lossLabel";
            this.lossLabel.Size = new System.Drawing.Size(52, 13);
            this.lossLabel.TabIndex = 11;
            this.lossLabel.Text = "Losses: 0";
            // 
            // WLRLabel
            // 
            this.WLRLabel.AutoSize = true;
            this.WLRLabel.Location = new System.Drawing.Point(135, 103);
            this.WLRLabel.Name = "WLRLabel";
            this.WLRLabel.Size = new System.Drawing.Size(84, 13);
            this.WLRLabel.TabIndex = 12;
            this.WLRLabel.Text = "W/L Ratio: 0.00";
            // 
            // Blackjack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 228);
            this.Controls.Add(this.WLRLabel);
            this.Controls.Add(this.lossLabel);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.deckLabel);
            this.Controls.Add(this.aceLabel);
            this.Controls.Add(this.stayButton);
            this.Controls.Add(this.secondDealerCard);
            this.Controls.Add(this.firstDealerCard);
            this.Controls.Add(this.dealerTotalLabel);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.secondCard);
            this.Controls.Add(this.firstCard);
            this.Name = "Blackjack";
            this.Text = "Blackjack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstCard;
        private System.Windows.Forms.Label secondCard;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Label dealerTotalLabel;
        private System.Windows.Forms.Label firstDealerCard;
        private System.Windows.Forms.Label secondDealerCard;
        private System.Windows.Forms.Button stayButton;
        private System.Windows.Forms.Label aceLabel;
        private System.Windows.Forms.Label deckLabel;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Label lossLabel;
        private System.Windows.Forms.Label WLRLabel;
    }
}

