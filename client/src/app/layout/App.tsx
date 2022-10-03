import "./App.css";
import { store, history } from "../../store";
import { Provider } from "react-redux";
import { HistoryRouter as Router } from "redux-first-history/rr6";
import { Route, Routes } from "react-router-dom";
import HomePage from "../features/home/HomePage";

function App() {
    return (
        <Provider store={store}>
            <Router history={history}>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                </Routes>
            </Router>
        </Provider>
    );
}

export default App;
