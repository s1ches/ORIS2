import React from 'react';
import PokemonType from "./pokemonType/PokemonType";

const PokemonCard = (props) => {
    let pokemon = props.props;

    return (
        <div className="pokemon-card">
            <div className="card-header">
                <div className="pokemon-name">
                    {pokemon?.name[0].toUpperCase() + pokemon?.name.slice(1)}
                </div>
                <div className="pokemon-id">
                    #{pokemon?.id.toString().padStart(3, '0')}
                </div>
            </div>
            <div className="card-content">
                <img alt="" className="card-image" src={pokemon?.imgUrl}/>
            </div>
            <div className="card-footer">
                {pokemon?.typeArr.map(type => (
                    <PokemonType style={{background: type.color}}> {type.typeName}</PokemonType>))}
            </div>
        </div>
    );
};

export default PokemonCard;