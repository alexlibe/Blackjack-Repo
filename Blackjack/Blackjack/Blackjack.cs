using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Blackjack
{
    public partial class Blackjack : Form
    {
        const int MAX_CARDS = 52, BLACKJACK = 21;
        readonly int[] staticDeck = new int[MAX_CARDS];
        Random rng = new Random();

        List<int> deck = new List<int>();
        List<int> discardDeck = new List<int>();
        List<int> cardsInHand = new List<int>();
        List<int> dealerHand = new List<int>();

        Point lastLabelPosition, lastDealerLabelPosition;
        int playerTotal = 0, dealerTotal = 0, wins = 0, losses = 0;

        public Blackjack()
        {
            InitializeComponent();

            // Sets all the cards in the static deck
            int cardNumber = 1;
            int cardAmount = 1;
            for (int i = 0; i < MAX_CARDS; i++)
            {
                staticDeck[i] = cardNumber;
                discardDeck.Add(cardNumber);
                if (++cardAmount == 5 && cardNumber != 10)
                {
                    ++cardNumber;
                    cardAmount = 1;
                }
            }
            Shuffle(); // Shuffles the dynamic deck

            // Initializations
            AddCard(firstCard, true);
            AddCard(secondCard, true);
            firstCard.Click += Label_Clicked;
            secondCard.Click += Label_Clicked;

            AddCard(firstDealerCard, false);
            AddCard(secondDealerCard, false);
            if (secondDealerCard.Text == "A")
            {
                dealerTotalLabel.Text = "Dealer Total: 11";
            }
            else
            {
                dealerTotalLabel.Text = "Dealer Total: " + secondDealerCard.Text;
            }

            firstDealerCard.Click += Label_Clicked;
            secondDealerCard.Click += Label_Clicked;

            lastLabelPosition = secondCard.Location;
            lastDealerLabelPosition = secondDealerCard.Location;
        }

        private void Shuffle()
        {
            // Adds the all the discarded cards to a temp list
            List<int> addedIndexes = new List<int>();
            for (int i = 0; i < discardDeck.Count; i++)
            {
                addedIndexes.Add(discardDeck[i]);
            }

            // Randomly generates an index in the temp list and adds it to the deck to shuffle
            while (addedIndexes.Count > 0)
            {
                int cardIndex = rng.Next(0, addedIndexes.Count);
                deck.Add(addedIndexes[cardIndex]);
                addedIndexes.RemoveAt(cardIndex);
            }
            discardDeck.Clear();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            Label nextCard = new Label();
            nextCard.AutoSize = true;
            nextCard.Name = "label";
            nextCard.Click += Label_Clicked;
            nextCard.Location = new Point(lastLabelPosition.X + 25, lastLabelPosition.Y);
            lastLabelPosition = nextCard.Location;
            AddCard(nextCard, true);

            Controls.Add(nextCard);

            if (AceCheckFailed())
            {
                firstDealerCard.Visible = true;
                dealerTotalLabel.Text = "Dealer Total: " + dealerTotal.ToString();
                MessageBox.Show("You Busted!", "Game Ended");
                Restart(false);
            }
        }

        private void AddCard(Label cardLabel, bool isPlayer)
        {
            // Checks if the deck has any cards and then shuffles       
            if(deck.Count == 0)
            {
                Shuffle();
            }

            // Checks if the next card was an ace and changes the label to an A
            if (deck[0] == 1)
            {
                cardLabel.Text = "A";
            }
            else
            {
                cardLabel.Text = deck[0].ToString();
            }

            if (isPlayer)
            {
                // Makes the aces an 11 by default
                if (deck[0] == 1)
                {
                    cardsInHand.Add(11);
                    cardLabel.Tag = 11;
                }
                else
                {
                    cardsInHand.Add(deck[0]);
                }

                playerTotal += cardsInHand[cardsInHand.Count - 1];
                totalLabel.Text = "Total: " + playerTotal.ToString();


            }
            else        
            {
                // Makes the aces an 11 by default
                if (deck[0] == 1)
                {
                    dealerHand.Add(11);
                    cardLabel.Tag = 11;
                }
                else
                {
                    dealerHand.Add(deck[0]);
                }

                dealerTotal += dealerHand[dealerHand.Count - 1];
                dealerTotalLabel.Text = "Dealer Total: " + dealerTotal.ToString();
            }

            // Removes the top card
            discardDeck.Add(deck[0]);
            deck.RemoveAt(0);
            deckLabel.Text = "Cards in Deck: " + deck.Count;
        }

        private void Restart(bool didPlayerWin)
        {
            cardsInHand.Clear();
            dealerHand.Clear();
            firstDealerCard.Visible = false;
            aceLabel.Text = string.Empty;
            lastLabelPosition = secondCard.Location;
            lastDealerLabelPosition = secondDealerCard.Location;
            playerTotal = 0;
            dealerTotal = 0;

            List<Label> controlsToDelete = new List<Label>();
            foreach (Control value in Controls)
            {
                if (value.Name == "label")
                {
                    Label extraLabel = (Label)value;
                    controlsToDelete.Add(extraLabel);
                }
            }

            foreach (Label value in controlsToDelete)
            {
                Controls.Remove(value);
            }

            AddCard(firstCard, true);
            AddCard(secondCard, true);

            AddCard(firstDealerCard, false);
            AddCard(secondDealerCard, false);
            if (secondDealerCard.Text == "A")
            {
                dealerTotalLabel.Text = "Dealer Total: 11";
            }
            else
            {
                dealerTotalLabel.Text = "Dealer Total: " + secondDealerCard.Text;
            }

            if (didPlayerWin)
            {
                ++wins;
                winLabel.Text = "Wins: " + wins.ToString();
            }
            else
            {
                ++losses;
                lossLabel.Text = "Losses: " + losses.ToString();
            }

            float wlRatio = (float)wins / losses;
            WLRLabel.Text = "W/L Ratio: " + wlRatio.ToString("F2");
        }

        private void stayButton_Click(object sender, EventArgs e)
        {
            // The dealer keeps hitting until they're at or above 16
            while (dealerTotal < 16)
            {
                Label nextCard = new Label();
                nextCard.AutoSize = true;
                nextCard.Name = "label";
                nextCard.Click += Label_Clicked;
                nextCard.Location = new Point(lastDealerLabelPosition.X + 25, lastDealerLabelPosition.Y);
                lastDealerLabelPosition = nextCard.Location;

                AddCard(nextCard, false);
                Controls.Add(nextCard);
            }
            dealerTotalLabel.Text = "Dealer Total: " + dealerTotal.ToString();
            firstDealerCard.Visible = true;

            bool didPlayerWin = false;
            if ((dealerTotal > BLACKJACK || playerTotal > dealerTotal) && playerTotal <= BLACKJACK)
            {
                MessageBox.Show("You Won!", "Game Ended");
                didPlayerWin = true;
            }
            else if (playerTotal == dealerTotal)
            {
                if (cardsInHand.Count > dealerHand.Count)
                {
                    MessageBox.Show("You Lost!", "Game Ended");
                }
                else if(cardsInHand.Count < dealerHand.Count)
                {
                    MessageBox.Show("You Won!", "Game Ended");
                    didPlayerWin = true;
                }
                else
                {
                    MessageBox.Show("You Tied!", "Game Ended");
                }
            }
            else
            {
                MessageBox.Show("You Lost!", "Game Ended");
            }
            Restart(didPlayerWin);
        }

        private void Label_Clicked(object sender, EventArgs e)
        {
            Label labelClicked = (Label)sender;
            if (labelClicked.Text == "A")
            {
                for (int i = 0; i < cardsInHand.Count; i++)
                {
                    if (cardsInHand[i] == (int)labelClicked.Tag)
                    {
                        if (cardsInHand[i] == 1)
                        {
                            cardsInHand[i] = 11;
                            playerTotal = --playerTotal + 11;
                            labelClicked.Tag = 11;
                            break;
                        }
                        else
                        {
                            cardsInHand[i] = 1;
                            playerTotal = ++playerTotal - 11;
                            labelClicked.Tag = 1;
                            break;
                        }
                    }
                }

                totalLabel.Text = "Total: " + playerTotal.ToString();
                if (playerTotal > BLACKJACK)
                {
                    aceLabel.Text = "Your ace can be switched";
                }
                else
                {
                    aceLabel.Text = string.Empty;
                }
            }
        }

        // Checks if the player bust or not depending on whether the ace values are switched
        private bool AceCheckFailed()
        {
            int handLength = cardsInHand.Count;

            int[] tempPlayerHand = new int[handLength];
            List<int> aceIndexes = new List<int>();

            for (int i = 0; i < handLength; ++i)
            {
                int cardValue = cardsInHand[i];
                tempPlayerHand[i] = cardValue;

                if (cardValue == 1 || cardValue == 11)
                {
                    aceIndexes.Add(i);
                }
            }

            int firstIndex = -1;
            foreach(int i in aceIndexes)
            {
                if (firstIndex == -1)
                {
                    tempPlayerHand[i] = 11;
                    firstIndex = i;
                }
                else
                {
                    tempPlayerHand[i] = 1;
                }
            }

            int tempTotal = tempPlayerHand.Sum();
            if (firstIndex != -1)
            {
                if (tempTotal > BLACKJACK)
                {
                    tempPlayerHand[firstIndex] = 1;
                    tempTotal = tempPlayerHand.Sum();

                    if (tempTotal > BLACKJACK)
                    {
                        totalLabel.Text = "Total: " + tempTotal.ToString();
                        return true;
                    }
                    else
                    {
                        aceLabel.Text = "Your ace can be switched";
                        return false;
                    }
                }
            }

            if (playerTotal > BLACKJACK)
            {
                return true;
            }

            return false;
        }
    }
}
