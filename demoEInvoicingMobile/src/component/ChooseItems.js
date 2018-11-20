import React,{Component} from 'react'
import {View,Text,FlatList,Image,TouchableOpacity,Button,TextStyle} from 'react-native'
import Css from '../Css/Css';


const data = [
    {
        ItemsName: 'Game Book',
        ItemsIcon: require('../assets/logo/gameDev_icon.jpg'),
        ItemsPrice: 0,
        ItemsNum: 1
    },
    {
        ItemsName: 'React Native Book',
        ItemsIcon: require('../assets/logo/reactNative_icon.jpg'),
        ItemsPrice:200000,
        ItemsNum:2
    },
    {
        ItemsName: 'Android Book',
        ItemsIcon: require('../assets/logo/android_icon.png'),
        ItemsPrice: 135000,
        ItemsNum: 4
    },
    {
        ItemsName: 'iOs Book',
        ItemsIcon: require('../assets/logo/ios_icon.png'),
        ItemsPrice: 120000,
        ItemsNum: 3
    },
    {
        ItemsName: 'Java Book',
        ItemsIcon: require('../assets/logo/java_icon.png'),
        ItemsPrice: 400000,
        ItemsNum: 2
    },
    {
        ItemsName: 'Web Book',
        ItemsIcon: require('../assets/logo/webDev_icon.png'),
        ItemsPrice: 32000,
        ItemsNum: 5
    },
    {
        ItemsName: 'Manga Book',
        ItemsIcon: require('../assets/logo/manga_icon.png'),
        ItemsPrice: 260000,
        ItemsNum: 2
    },
    {
        ItemsName: 'Marvel Book',
        ItemsIcon: require('../assets/logo/marvel_icon.png'),
        ItemsPrice: 100000,
        ItemsNum: 2
    }
];

class FlatListItem extends Component{
    
    render(){
        
        return(
            <View style={Css.containerFlatListItem}>
                <View style={Css.ViewAnh}>
                    <Image style={Css.image} source={this.props.item.ItemsIcon}/>
                </View>
                <TouchableOpacity style={Css.flex1} >
                    <View style={Css.ViewTitle}>
                        <Text style={Css.Text}>{this.props.item.ItemsName}</Text>
                        <Text style={Css.Text}>{this.props.item.ItemsPrice} đồng</Text>
                    </View>
                    <View style={Css.ViewDauChuyenTiep}>
                         <Text style={Css.dauChuyenTiep}>.</Text>
                    </View>
                </TouchableOpacity>
            </View>
        );
    }
}

export default class ChooseItems extends Component{
    
    constructor(props){
        super(props);
        this.state={data:[],totalPrice:0}
        
    }
    componentDidMount(){
        this.setState({data:data})
        this.getTotalPrice();
    }
    getTotalPrice = () => {
        let totalP=0;
        data.forEach((value)=>{
            totalP=totalP+value.ItemsPrice;
        })
        this.setState({totalPrice:totalP})
    }
    render(){
        const {navigate} = this.props.navigation;
        let totalPrice = this.state.totalPrice;
        let data = this.state.data;
        return(
            <View style={Css.containerChooseItems}>
                <View style={Css.containerChooseItemsHeader}>
                    <Text style={{fontSize:20,fontWeight:'bold'}}>Bạn đã mua :</Text>
                </View>
                <View style={Css.containerChooseItemslist}>
                    <FlatList
                        data = {this.state.data}
                        keyExtractor = {(item,index)=>index.toString()}
                        renderItem={({item})=>{
                            return(
                                <FlatListItem item={item} navigate={navigate}></FlatListItem>
                            );
                        }}
                    />
                </View>
                <View style={Css.containerChooseItemButton}>
                        <Button title='Thanh toán' color='#000000'
                        onPress={()=>this.props.navigation.navigate('getCus',{
                            totalPrice:totalPrice,
                            data:data
                        })}/>
                </View>
            </View>
        )
    }
}