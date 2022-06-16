import React, { createContext, Component } from "react";
import API from './utils/api.js';

export const AppContext = createContext();

class AppContextProvider extends Component {

    state = {
        allFires: null,
        historicalData: null,
    }

    getAllFires = () => {

        API.getAllFires().then(response => response.json())
            .then(data => {
                this.setState({ allFires: data });
            })
            .catch(err => console.log(err));
    };





    render() {

        return (
            <AppContext.Provider value={{
                allFires: this.state.allFires,
                getAllFires: this.getAllFires,
            }}>
                {this.props.children}
            </AppContext.Provider>
        );
    }
}

export default AppContextProvider;