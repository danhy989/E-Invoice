
import {createStackNavigator,createNavigationContainer}from 'react-navigation'
import Home from '../component/Home';
import ChooseItems from '../component/ChooseItems';
import  GetCustomer from '../component/GetCustomer';
import Finish from '../component/finish';

const RootStackNavigator = createStackNavigator(
    {
        home:{
            screen:Home
        },
        chooseItems:{
            screen:ChooseItems
        },
        getCus:{
            screen:GetCustomer
        },
        finish:{
            screen: Finish
        }
    },
    {
        initialRouteName:'home'
    },
)

export default RootStackContainer = createNavigationContainer(RootStackNavigator);