import React, {useEffect, useState} from 'react';
import PokemonsList from "./components/pokemonsList/PokemonsList";
import Finder from "./components/finder/Finder";
import invokePokemon from "../../functions/pokemonsInvoker";
import isEqualsPokemonsArrays from "../../functions/isEqualsPokemonsArrays";

const MainPage = () => {
    const [pokemonName, setPokemonName] = useState('');
    const [pokemons, setPokemons] = useState([]);
    const [fetching, setFetching] = useState(true);
    const [namesLinks, setNamesLinks] = useState([]);
    const [start, setStart] = useState(1);
    const [stop, setStop] = useState(30);
    const [lastFetched, setLastFetched] = useState('all');
    const [isLoading, setIsLoading] = useState(true);

    const [countPokemons, setCountPokemons] = useState(100);

    useEffect(() => {
        const fetchCount = async () => {
            let data = await (await fetch('https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0')).json();

            setCountPokemons(data?.count);
            setNamesLinks(data?.results);
        }

        if (countPokemons === 100)
            fetchCount();

    }, [])

    useEffect(() => {
        const fetchData = async () => {
            const result = []

            if (pokemonName === "" || pokemonName === undefined) {
                if (lastFetched !== "all") {
                    setLastFetched("all");
                    setStart(1);
                    setStop(30);

                    for (let i = 1; i <= 30; ++i)
                        result.push(await invokePokemon(i));

                    setPokemons(result);
                }else {
                    for (let i = start; i <= stop; ++i)
                        result.push(await invokePokemon(i));

                    setPokemons([...pokemons, ...result]);
                }
            } else {
                const neededNamesLinks = namesLinks.filter(x => x?.name.toLowerCase().includes(pokemonName.toLowerCase()));

                if (lastFetched !== "byName") {
                    setLastFetched("byName");
                    setStart(1);
                    setStop(30);
                    for (let i = 1; i <= 30 && i < neededNamesLinks.length; ++i) {
                        console.log(neededNamesLinks[i]?.name);
                        result.push(await invokePokemon(neededNamesLinks[i]?.name));
                    }

                    let fetchedNeededPokes = pokemons.filter(p => p?.name.toLowerCase().includes(pokemonName.toString().toLowerCase()) && !result.map(r => r.id).includes(p?.id));
                    setPokemons([...fetchedNeededPokes, ...result]);
                } else {
                    for (let i = start; i <= stop && i < neededNamesLinks.length; ++i) {
                        result.push(await invokePokemon(neededNamesLinks[i]?.name));
                    }

                    setPokemons([...pokemons, ...result]);
                }
            }

            setStart(stop + 1);
            setStop(stop + 30);
            setIsLoading(false);
        };

        if (fetching) {
            setIsLoading(true);
            fetchData();
            setFetching(false);
        }
    }, [fetching, pokemonName]);

    const findPokemons = (pokemons, pokemonName) => {
        if (pokemonName === '')
            return pokemons;

        let newPokemons = []

        for (let i = 0; i < pokemons.length; ++i) {
            if (pokemons[i].name.includes(pokemonName.toLowerCase()))
                newPokemons[newPokemons.length] = pokemons[i];
        }

        return newPokemons;
    }

    useEffect(() => {
        document.addEventListener("scroll", scrollHandler);

        return function () {
            document.removeEventListener("scroll", scrollHandler);
        };
    }, []);

    const scrollHandler = (event) => {
        if ((event.target.documentElement.scrollHeight - (event.target.documentElement.scrollTop + window.innerHeight) < 150)
            && stop < countPokemons) {
            setFetching(true);
        }
    }

    return (
        <div>
            <Finder onChange={event => {
                setIsLoading(true);
                setFetching(true);
                return setPokemonName(event.target.value)
            }}/>
            <PokemonsList pokemons={findPokemons(pokemons, pokemonName)} isLoading={isLoading}/>
        </div>
    );
};

export default MainPage;