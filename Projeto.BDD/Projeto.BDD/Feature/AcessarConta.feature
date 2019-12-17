#language: pt

Funcionalidade: AcessarConta
	Como um usuário da loja de livros
	Eu preciso acessar minha conta
	Para que eu possa realizar compras


Esquema do Cenário: Autenticação de usuário com sucesso
	Dado Acessar a página de login de usuários
	E Infomar o email <email>
	E Infomar o a senha <senha>
	Quando Solicitar o acesso
	Então Sistema autentica o usuário

	Exemplos:
	| email                   | senha        |
	| "sergio.coti@gmail.com" | "adminadmin" |
	| "ana.maria@gmail.com"	| "adminadmin" |	


Cenário: Acesso Negado
	Dado Acessar a página de login de usuários
	E Infomar o email "teste@gmail.com"
	E Infomar o a senha "adminadmin"
	Quando Solicitar o acesso
	Então Sistema exibe mensagem "Usuário ou Senha inválido"