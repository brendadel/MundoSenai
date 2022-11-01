using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {

        // Código para jogo da galinha

        // As variáveis ​​começam aqui

        int pipeSpeed = 8; // velocidade de tubulação padrão definida com um inteiro
        int gravity = 15; // velocidade de gravidade padrão definida com um inteiro
        int score = 0; // inteiro de pontuação padrão definido como 0
        // a variável termina

        public Form1()
        {
            InitializeComponent();
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            // este é o evento chave do jogo está inativo que está vinculado ao formulário principal
            if (e.KeyCode == Keys.Space)
            {
                // se a tecla de espaço for pressionada, a gravidade será definida como -15
                gravity = -15;
            }


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            // este é o evento key is up do jogo que está vinculado ao formulário principal

            if (e.KeyCode == Keys.Space)
            {
                // se a tecla de espaço for solta, a gravidade volta para 15
                gravity = 15;
            }

        }

        private void endGame()
        {
            // esta é a função de fim do jogo, esta função irá quando o pássaro tocar o chão ou os canos
            gameTimer.Stop();//para o temporizador principal
            scoreText.Text += " Fim de jogo!!!"; // mostra o game over text no texto da pontuação, += é usado para adicionar a nova string de texto ao lado da pontuação em vez de substituí-la
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;// vincula a caixa de imagem do flappy bird à gravidade, += significa que ele adicionará a velocidade da gravidade à localização superior da caixa de imagem para que ela se mova para baixo
            pipeBottom.Left -= pipeSpeed;// liga a posição esquerda do tubo inferior ao número inteiro da velocidade do tubo, ele reduzirá o valor da velocidade do tubo da posição esquerda da caixa de imagem do tubo para que ele se mova para a esquerda a cada tique
            pipeTop.Left -= pipeSpeed; // o mesmo está acontecendo com o tubo superior, reduza o valor do número inteiro da velocidade do tubo da posição esquerda do tubo usando o sinal -=
            scoreText.Text = "Score: " + score; // mostra a pontuação atual no rótulo de texto da pontuação
            // abaixo estamos verificando se algum dos pipes saiu da tela

            if (pipeBottom.Left < -150)
            {
                // se a localização dos tubos inferiores for -150, nós o redefiniremos para 800 e adicionaremos 1 à pontuação
                pipeBottom.Left = 800;
                score++;
            }
            if(pipeTop.Left < -180)
            {
                // se a localização do topo do pipe for -180 então vamos redefinir o pipe de volta para 950 e adicionar 1 à pontuação
                pipeTop.Left = 950;
                score++;
            }

            // a instrução if abaixo está verificando se o cano atingiu o chão, canos ou se o jogador saiu da tela por cima
            // os dois símbolos pipe representam OR dentro de uma instrução if para que possamos ter várias condições dentro desta instrução if porque tudo fará a mesma coisa

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
                // se alguma das condições acima for atendida, executaremos a função de fim de jogo
                endGame();
            }


            // se a pontuação for maior que 5, aumentaremos a velocidade do tubo para 15
            if (score > 5)
            {
                pipeSpeed = 15;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
