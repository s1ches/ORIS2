import React, { useEffect, useState, useCallback } from 'react';
import PokemonsList from "./components/pokemonsList/PokemonsList";
import Finder from "./components/finder/Finder";

const MainPage = () => {
    const [searchValue, setSearchValue] = useState('');
    const [isLoading, setIsLoading] = useState(true);
    const [pokemons, setPokemons] = useState([]);
    const [page, setPage] = useState(0);
    const [isSwitchingLoading, setIsSwitchingLoading] = useState(false);
    const count = 16;
    const [currentSearchValue, setCurrentSearchValue] = useState(searchValue);

    const fetchData = useCallback(async () => {
        console.log(page);
        let requestUri = `https://localhost:44340/api/Pokemon/GetAllPokemons?pokemonsCount=${count}&pageNumber=${page}`;

        if (searchValue !== '')
            requestUri = `https://localhost:44340/api/Pokemon/GetPokemonsByFilter/${searchValue}?pokemonsCount=${count}&pageNumber=${page}`;

        console.log(`searching by url:\n${requestUri}`);

        const response = await fetch(requestUri);
        const fetchedPokemons = await response.json();

        if (isSwitchingLoading) {
            setPokemons(fetchedPokemons);
            setPage(1);
        } else {
            setPokemons([...pokemons, ...fetchedPokemons]);
            setPage(page + 1);
        }

        setIsLoading(false);
        setIsSwitchingLoading(false);
        console.log(`pokemons on ${page} fetched`);
    }, [searchValue, isLoading, page, isSwitchingLoading, pokemons]);

    useEffect(() => {
        if (isLoading === true) {
            fetchData();
        }
    }, [isLoading, fetchData]);

    useEffect(() => {
        document.addEventListener("scroll", scrollHandler);

        return () => {
            document.removeEventListener("scroll", scrollHandler);
        };
    }, []);

    const scrollHandler = (event) => {
        if (event.target.documentElement.scrollHeight - (event.target.documentElement.scrollTop + window.innerHeight) < 200) {
            setIsLoading(true);
        }
    }

    const handleButtonClick = useCallback(() => {
        if (currentSearchValue !== searchValue) {
            setPage(0);
            setIsSwitchingLoading(true);
            setIsLoading(true);
            setPokemons([]);
            setSearchValue(currentSearchValue);
        }
    }, [currentSearchValue, searchValue]);

    return (
        <div>
            <Finder onChange={event => setCurrentSearchValue(event.target.value)}
                    onButtonClick={handleButtonClick}
            />
            <PokemonsList pokemons={pokemons} isLoading={isLoading}/>
        </div>
    );
};

export default MainPage;
