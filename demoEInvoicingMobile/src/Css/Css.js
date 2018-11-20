import {StyleSheet,Dimensions} from 'react-native'
export default Css = StyleSheet.create({
    container:{
        flex:1,
        backgroundColor:'white',
        alignItems:'center',
    },
    containerLogo:{
        flex:1,
        marginTop:20
    },
    
    containerInforTeam:{
        flex:1,
        paddingTop:30,
        alignItems:'center'
    },
    fontTextTitle:{
        fontWeight:'bold',
        fontSize:20,
        margin:10
    },
    fontTextInfor:{
        fontSize:15,
        margin:10,
    },
    containerButton:{
        flex:1,
        marginTop:10,
        marginBottom:10,
    },
    containerChooseItems:{
        flex:1,

    },
    containerChooseItemsHeader:{
        flex:1
    },
    containerChooseItemslist:{
        flex:8
    },
    containerChooseItemTotal:{
        borderTopWidth:1,
        flex:1,
        flexDirection:'row'
    },
    containerChooseItemButton: {
        borderTopWidth: 1,
        flex: 1,
        
    },
    //flat list items
    containerFlatListItem:{
        flexDirection:'row',
        flex:1,
        margin:1,
        
        height: 130,
        borderBottomWidth:0.25
    },
    
    image:{
        width:70,
        height:70
    },
    dauChuyenTiep:{
        fontSize:25,
        opacity:10,
    },
    ViewAnh:{
        flex:1,
        justifyContent:'center',
        alignItems:'center'
    },
    ViewTitle:{
        flex:5,
        fontSize:15,
        marginTop:0,
        marginLeft:3,
        marginRight:3,
        padding:2,
        justifyContent: 'center',
            alignItems: 'center'
    },
    ViewDauChuyenTiep:{
        flex:1,
        justifyContent:'center',
        alignItems:'flex-end',
        marginRight:10,
    },
    flex1:{
        flex:3,
        flexDirection:'row'
    },
    //getCus
    containerGetCus:{
        flex:1
    },
    containerGetCusHeader:{
        flex:1,
        alignItems:'center',
        marginTop:10
    },
    containerGetCusBody:{
        flex:8,
        alignItems:'center'
    },
    
    getCusItemTextInPut:{
        borderWidth:0.5,
        margin:10,
        width: Dimensions.get('window').width-30,
    },
    viewTongTien:{
        flex:1,
        alignItems:'flex-end',
    },
    textTotalPrice:{
        marginRight:35,
        color:'red',
        fontSize:20
    }

   
})