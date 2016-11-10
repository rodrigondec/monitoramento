<h1>Sistema de Monitoramento</h1>
<p>O Sistema de Monitoramento realiza o monitoramento de um ambiente através de 4 subsistemas e seus sensores.</p>

<h2>Subsistemas</h2>

<h3>Sensoriamento In Loco</h3>
<p>Esse subsistema é resposável por coletar as informações de um ambiente através de sensores e enviar para o subsistema Integrador.</p>

<h3>Integrador de Sensores</h3>
<p>Esse subsistema é responsável por receber os dados dos sensores do(s) subsistema(s) de Sensoriamento e enviar para o subsistema Receptor de Dados.</p>
<p>Geralmente o Integrador fica no ambiente a ser monitorado, juntamente com o subsistema de Sensoriamento. Então pode haver sensores adicionais nele também.</p>

<h3>Receptor de Dados</h3>
<p>Esse subsistema é responsável por receber os dados do subsistema Integrador e disponibilizá-los para a Interface. Logo ele precisa estar juntamente com o hardware que implementa a Interface.</p>

<h3>Interface</h3>
<p>A Interface é resposável por ler os dados do subsistema Receptor, salva-los no banco de dados utilizado e disponibilizar a visualização destes.</p>