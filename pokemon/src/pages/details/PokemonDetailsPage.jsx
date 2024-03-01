import React, {useEffect, useState} from 'react';
import {useParams} from "react-router-dom";
import typeToColor from "../../functions/typeToColor";
import Header from "./components/Header";
import PokemonCardDetails from "./components/PokemonCardDetails/PokemonCardDetails";
import Loading from "../../components/Loading";
import BreedingCard from "./components/BreedingCard";
import MovesCard from "./components/MovesCard";
import AbilitiesCard from "./components/AbilitiesCard";

const PokemonDetailsPage = () => {
    const [pokemonDetails, setPokemonDetails] = useState({
        id: 0,
        name: "",
        types: [{typeName: "", typeColor: ""}],
        breeding: {height: 0, weight: 0},
        abilities: [],
        moves: [],
        stats: {hp: 0, attack: 0, defense: 0, speed: 0}
    });

    const pokemonName = useParams();

    useEffect(() => {
        const fetchData = async () => {
            const poke = await (await fetch(`https://pokeapi.co/api/v2/pokemon/${pokemonName.name}`)).json();
            setPokemonDetails({
                id: poke?.id,
                name: poke?.forms[0]?.name,
                breeding: {height: poke?.height, weight: poke?.weight},
                types: poke?.types?.map(x => {return {typeName: x?.type?.name, typeColor: typeToColor(x?.type?.name)}}),
                abilities: poke?.abilities.map(x => x?.ability?.name),
                moves: poke?.moves.map(x => x?.move?.name),
                stats: {
                    hp: poke?.stats?.filter(x => x?.stat?.name === "hp")[0]?.base_stat,
                    attack: poke?.stats?.filter(x => x?.stat?.name === "attack")[0]?.base_stat,
                    defense: poke?.stats?.filter(x => x?.stat?.name === "defense")[0]?.base_stat,
                    speed: poke?.stats?.filter(x => x?.stat?.name === "speed")[0]?.base_stat,
                }
            });
        };
        fetchData();
    }, []);

    console.log(pokemonDetails);

    if(pokemonDetails.id !== 0)
        return (
            <>
                <Header />
                <div className="pokemon-details-wrapper">
                    <PokemonCardDetails pokemon={pokemonDetails} />
                    <BreedingCard pokemon={pokemonDetails}/>
                    <MovesCard pokemon={pokemonDetails} />
                    <AbilitiesCard pokemon={pokemonDetails} />
                </div>
            </>
        );

    return (
        <>
            <Header />
            <Loading />
        </>

    )
};

export default PokemonDetailsPage;