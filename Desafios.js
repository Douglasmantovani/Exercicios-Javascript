
//Le os nomes do array
var Nomes=['Douglas','Marcos','Andre']
Nomes.forEach(function(nome){console.log(nome)})



var Canais=['Globo','Record','Sbt'];
//valores adicionados ao array no meio da leitura sao ignorados
Canais.forEach(function(canal){Canais.push('RedeTv'); console.log(canal)})

//vai ler o canal q foi adicionado
console.log(Canais);


//Faz uma operaçaopara cada item do array
var numeros=[1,2,3];
var Dobro=numeros.map(function(numero){return numero *2})
console.log(numeros);
console.log(Dobro);


//Filtra todos os itens do array,retorna todos os alunos maior de idade
var alunos=[{Nome:'Douglas',Idade:'18'},
{Nome:'Marcos',Idade:'18'},
{Nome:'Andre',Idade:'18'}]
var alunosDemaior=alunos.map(function(aluno){return aluno.Idade >=18})
console.log(alunosDemaior);


//Busca item no array com caracteristicas iguais
var Pessoas=[{Nome:"Douglas"},{Nome:"Marcos"},{Nome:"Andre"}]
var NomeBuscado=Pessoas.find(function(pessoa){return pessoa.Nome==='Douglas'});
console.log(NomeBuscado);

//Verifica se todos os itens do array cumprem com a condicao definida se todos cumprirem retorna true,senao false
var alunos=
[{Nome:'Douglas',Idade:'17'},
{Nome:'Marcos',Idade:'18'},
{Nome:'Andre',Idade:'18'}]
var Verificacao=alunos.every(function(aluno){return aluno.Idade>=18})
console.log(Verificacao);

//Verifica se existe pelomenos um item no array que cumpre com a condicao
var PesoMalas=[12,23,45];
var VerificarPesomalas=PesoMalas.some(function(pesomala){return pesomala>35});
console.log(VerificarPesomalas);


//Soma todos os itens do array
var numeros=[2,5,7,8,9]
var Soma=0;
soma=numeros.reduce(function(soma,numero){return soma+numero})

