import React, {useEffect, useState} from 'react';
import {useParams} from "react-router-dom";
import Header from "./components/Header";
import PokemonCardDetails from "./components/PokemonCardDetails/PokemonCardDetails";
import Loading from "../../components/Loading";
import BreedingCard from "./components/BreedingCard";
import MovesCard from "./components/MovesCard";
import AbilitiesCard from "./components/AbilitiesCard";
import typeToColor from "../../functions/typeToColor";

const PokemonDetailsPage = () => {
    const [pokemonDetails, setPokemonDetails] = useState({
        id: 0,
        name: "",
        imageUrl: "",
        types: [{typeName: "", typeColor: ""}],
        breeding: {height: 0, weight: 0},
        abilities: [],
        moves: [],
        stats: {hp: 0, attack: 0, defense: 0, speed: 0}
    });

    let isLoading = true;
    const pokemonName = useParams();

    useEffect(() => {
        const fetchData = async () => {
            fetch(`https://localhost:44340/api/Pokemon/GetPokemonByIdOrName/${pokemonName.name}`)
                .then(response => response.json())
                .then(poke => setPokemonDetails({
                    id: poke?.id,
                    name: poke?.name,
                    imageUrl: poke?.imageUrl,
                    breeding: {height: poke?.height, weight: poke?.weight},
                    types: poke?.types.map(t => {return {typeName: t, typeColor: typeToColor(t)}}),
                    abilities: poke?.abilities,
                    moves: poke?.moves,
                    stats: {
                        hp: poke?.stats?.filter(x => x?.statName === "hp")[0]?.statValue,
                        attack: poke?.stats?.filter(x => x?.statName === "attack")[0]?.statValue,
                        defense: poke?.stats?.filter(x => x?.statName === "defense")[0]?.statValue,
                        speed: poke?.stats?.filter(x => x?.statName === "speed")[0]?.statValue,
                    }
                }));
        };

        fetchData().then(r => console.log('fetched pokemonDetails'));
    }, [pokemonName.name]);

    if(pokemonDetails.id !== 0)
        isLoading = false;

    if(!isLoading)
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