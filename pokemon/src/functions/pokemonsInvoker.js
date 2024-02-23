import typeToColor from "./typeToColor";

async function getPokemons(limit, offset) {
    const response = await fetch(`https://pokeapi.co/api/v2/pokemon?limit=${limit}&offset=${offset}`);

    const pokemonListJson = await response.json();

    const pokemonsUrls = pokemonListJson?.results.map(pokemon => pokemon?.url);

    let pokemons = [];

    for(let i = 0; i < pokemonsUrls.length; ++i){
        let pokemon = {id: 0, name: "", typeArr: [{typeName: "", color: ""}], imgUrl: ""};

        let pokemonResponse = await fetch(pokemonsUrls[i]);
        let pokemonUrl = (await pokemonResponse.json())?.forms.map(p => p?.url);

        let pokemonJson = await (await fetch(pokemonUrl)).json();

        pokemon.id = pokemonJson?.id;
        pokemon.name = pokemonJson?.name;
        pokemon.typeArr = pokemonJson?.types.map(t => {return {typeName: t?.type?.name, color: typeToColor(t?.type?.name)}});
        pokemon.imgUrl =
            `https://raw.githubusercontent.com/pokeapi/sprites/master/sprites/pokemon/other/home/${pokemon.id}.png`;
        pokemons[i] = pokemon;
    }

    return pokemons;
}

async function invokeEachPokemon(limit){
    let result = [];

    for(let i = 1; i <= limit; i++){
        let response = await fetch(`https://pokeapi.co/api/v2/pokemon/${i}/`);
        let pokemonUrl = (await response.json())?.forms[0]?.url;

        let pokemon = {id: 0, name: "", typeArr: [{typeName: "", color: ""}], imgUrl: ""};

        let pokemonJson = await (await fetch(pokemonUrl)).json();

        pokemon.id = pokemonJson?.id;
        pokemon.name = pokemonJson?.name;
        pokemon.typeArr = pokemonJson?.types.map(t => {return {typeName: t?.type?.name, color: typeToColor(t?.type?.name)}});
        pokemon.imgUrl =
            `https://raw.githubusercontent.com/pokeapi/sprites/master/sprites/pokemon/other/home/${pokemon.id}.png`;

        console.log(i);
        result[result.length] = pokemon;
    }

    return result;
}

async function invokePokemons(){
    return await invokeEachPokemon(100);
}

export default invokePokemons;