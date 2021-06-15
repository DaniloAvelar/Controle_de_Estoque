Projeto Controle_de_Estoque

- Criando o Projeto
- Vinculando com GitHub
- Criando o Modelo de Produtos
- Criando o Modelo de Categorias
- Criando o DbContext
- Instalando EF (Entity FrameWork)

- Criando String de Conexão (MySql) - appsetting.json
- Registrando a Conexão no (Startup.cs)
- Instalando o Pacote de Conexao com MySql (Pomelo EF)
- Criando o Controller para (Produtos)
- Criando a View para exibir os produtos

- Implementação do método para (Novos itens "Ainda não existentes no BD")
- Criação de View para Cadastro de Novos itens
- Implementação do método para (Entrada de itens)
- Criação da View para entrada de itens
- Implementação do método para (Saída de itens)
- Criação da View para Saída de Itens 
- Implementação do método para (Delete de itens)
- Criação da View para Delete de Itens 

- Criação do Campo "Caixa" no Model (Produto), identificador de onde o produto se encontra
- Criação do método de calculo e geração de Nº da Caixa automaticamente, seguindo um sequencial
- Criação de alerta para impressão da etiqueta na view (Create)

- Criação da Classe (Saida) Model
- Criação da Classe (Entrada) Model
- Criação da Classe (Usuario) Model

- Criação do Controler [UsuariosController]
- Criação automática das Views [Create - Details - Edit - Delete] para o Model Usuario
- Criação do módulo de logs de entrada (A cada produto que entra, o mesmo guarda um log no sistema)
- Inserção do modulo de logs de retirada (A cada retirada de item do estoque, o mesmo grava na tabela retirada, mantendo assim um hiostorico)

