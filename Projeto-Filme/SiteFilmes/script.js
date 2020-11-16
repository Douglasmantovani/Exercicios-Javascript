async function BuscarFilme() {
    const URL = `http://localhost:5000/api/Filmes`;
    const Requisicao= await fetch(URL);
    const Resposta = await Requisicao.json()
    return Resposta;
}

const mainPageFilme= document.querySelector("#mainPage-Filme");
const mainPageGenero= document.querySelector("#mainPage-Genero")
const createElement = (tag) => document.createElement(tag);
const createTextNode = (element, text) => {
const textNode = document.createTextNode(text)
element.appendChild(textNode)
} 
const appendElements = (fatherElement, childElement) => fatherElement.appendChild(childElement)

async function ListarFilmes(){
    var Filmes=await BuscarFilme();
    for (filme of Filmes)
    {  const divFilme = createElement("div")
        const divGenero = createElement("div")

        const tituloFilm = await createElement("p")
         createTextNode(tituloFilm, filme.titulo)
        const generoFilme = await createElement("p")
        createTextNode(generoFilme, filme.idGeneroNavigation.nome)
        appendElements(divFilme, tituloFilm)
        appendElements(divGenero, generoFilme)
        appendElements(mainPageFilme, divFilme)
        appendElements(mainPageGenero, divGenero)
    }
}