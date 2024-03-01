import React from 'react';

const NotFound = () => {
    return (
        <div className="not-found-wrapper">
            <h2 className="oops" align="center">
                Oops! Try again.
            </h2>
            <br/>
            <p className="oops-text" align="center">
                The Pokemon you're looking for is a unicorn. It doesn't exist in this list.
            </p>
            <img className="not-found-pikachu" src="https://www.pokewiki.de/images/thumb/1/14/Pok%C3%A9monsprite_025g_SWSH.gif/128px-Pok%C3%A9monsprite_025g_SWSH.gif"/>
        </div>
    );
};

export default NotFound;