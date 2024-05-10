import React from 'react';

const PokemonType = ({children, ...props}) => {
    return (
        <div className="pokemon-type" {...props}>
            {children}
        </div>
    );
};

export default PokemonType;