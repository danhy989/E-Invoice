import React,{Component} from 'react'
import {View,Text,Button,Image} from 'react-native'
import Css from '../Css/Css';

export default class Home extends Component{
    render(){
        return(
            <View style={Css.container}>
                <View style={Css.containerLogo}>
                     <Image source={require('../assets/logo/e-invoicing-logo.png')}/>
                </View>
                <View style={Css.containerInforTeam}>
                     <Text style={Css.fontTextTitle}>App Demo : Hóa đơn điện tử </Text>
                     <Text style={Css.fontTextInfor}>Phần mềm di động tại máy khách</Text>
                     <Text style={Css.fontTextInfor}>SE101.J11</Text>
                </View>
                <View style={Css.containerButton}>
                    <Button
                    title='continue'
                    color='#000000'
                    onPress={()=>this.props.navigation.navigate('chooseItems')}
                    />
                </View>
            </View>
        )
    }
}