# language: pt-br
@ComprarPassagens
Funcionalidade: Comprar passagens pelo menor preço
Como passageiro
Eu quero comprar passagens aéreas 
Com o objetivo de obter as passagens com o menor valor do dia

@ComprarPassagensPeloMenorPreco
Cenario: Comprar passagens pelo menor preço
	Dado um passageiro que deseja realizar a compra de passagens pelo menos preço
	Quando o usuário seleciona o destino igual a "SDU" e o Destino igual a "GRU"
	E seleciono a opção para comprar as passagens de ida e de volta.
	E informo a data da ida  um dia superior a data atual
	E a data de volta dois meses superior a  data de ida
	E seleciono a quantidade de "2" adultos
	E seleciono a opção "Compre aqui"
	E seleciono a opção para organizar o voo de ida pela tarifa tarifa mais baixa;
	E seleciono a opção para organizar o voo de volta pela tarifa tarifa mais baixa;
	E seleciono a opção para filtrar o voo de ida pela tarifa com o menor preço;
	E seleciono a opção para filtrar o voo de volta pela tarifa com o menor preço;
	E seleciono "Comprar"
	Entao o Sistema exibe o resumo o resumo da compra das passagens de ida e volta com o menor preço e o o primeiro horário de voo

	