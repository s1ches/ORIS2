import typeToColor from "./typeToColor";

async function invokePokemon(i){
    let response = await fetch(`https://pokeapi.co/api/v2/pokemon/${i}/`);
    let pokemonUrl = (await response.json())?.forms[0]?.url;

    let pokemon = {id: 0, name: "", typeArr: [{typeName: "", color: ""}], imgUrl: ""};

    let pokemonJson = await (await fetch(pokemonUrl)).json();

    pokemon.id = pokemonJson?.id;
    pokemon.name = pokemonJson?.name;
    pokemon.typeArr = pokemonJson?.types.map(t => {return {typeName: t?.type?.name, color: typeToColor(t?.type?.name)}});
    pokemon.imgUrl = `https://projectpokemon.org/images/sprites-models/pgo-sprites/pm${pokemon.id}.icon.png`

    return pokemon;
}

export default invokePokemon;