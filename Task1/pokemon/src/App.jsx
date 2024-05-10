import "./styles/app.css"
import PokemonDetailsPage from "./pages/details/PokemonDetailsPage";
import {Route, Routes} from "react-router-dom";
import MainPage from "./pages/main/MainPage";

function App() {
   return (
    <div className="app">
        <Routes>
            <Route path={"/"} element={<MainPage />} />
            <Route path={"details/:name"} element={<PokemonDetailsPage />} />
        </Routes>
    </div>
  );
}

export default App;