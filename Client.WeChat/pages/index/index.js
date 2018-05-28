var util = require('../utils.js');
Page({
  data: {
    Pet: {
      id: 0,
      FilePaths: '',
      type: 0,
      tito: '',
      input: '',
      CreateTime: '',
      isLike: 0
    },
    list: [],
    tempFilePaths: ''
  },

  chooseimage: function () {
    var _this = this;
    wx.chooseImage({
      count: 1, // 默认9  
      sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有  
      sourceType: ['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有  
      success: function (res) {
        // 返回选定照片的本地文件路径列表，tempFilePath可以作为img标签的src属性显示图片  
        _this.setData({
          tempFilePaths: res.tempFilePaths
        })
      }
    })
  },
  save: function () {
    var Pet = this.data.Pet;
    var inti = this.data.list.length;
    var list = "list[" + inti + "]"
    this.setData({
      [list]: Pet
    })
    console.log(inti);
    wx.setStorageSync('person_list', this.data.list)
    this.setData({
      input: '',
      tempFilePaths: ''
    })
    wx.switchTab({
      url: '../main/Main'
    });
  },

  load: function () {
    var list = wx.getStorageSync('person_list')
    this.setData({
      list: list,
      //type: options,
    })
  },

  onLoad: function (options) {
    this.setData({
      type: options.id,
    })
    console.log('type!!!!!!!' + this.data.type);
    this.load()
  },

  removeInputHandle: function () {
    this.setData({
      input: ''
    })
  },

  inputChangeHandle: function (e) {
    this.setData({ tito: e.detail.value })
  },
  inputChangeHandle2: function (e) {
    this.setData({ input: e.detail.value })
  },
  addTodoHandle: function (e) {
    if (!this.data.input || !this.data.input.trim()) return
    var Petid = 'Pet.id';
    var PetFilePaths = 'Pet.FilePaths';
    var Pettype = 'Pet.type';
    var Petinput = 'Pet.input';
    var Pettime = 'Pet.CreateTime';
    var Pettito = 'Pet.tito';
    var PetisLike = 'Pet.isLike';
    this.setData({
      [Petid]: this.data.list.length + 1,
      [PetFilePaths]: this.data.tempFilePaths,
      [Petinput]: this.data.input,
      [Pettype]: this.data.type,
      [Pettito]: this.data.tito,
      [Pettime]: util.formatTime(new Date()),
      [PetisLike]: 0,
      [this.data.index]: this.data.index + 1
    })
    this.save()
  },

  toggleTodoHandle: function (e) {
    var index = e.currentTarget.dataset.index
    var todos = this.data.todos
    todos[index].completed = !todos[index].completed
    this.setData({
      todos: todos,
      leftCount: this.data.leftCount + (todos[index].completed ? -1 : 1)
    })
    this.save()
  },

  removeTodoHandle: function (e) {
    var index = e.currentTarget.dataset.index
    var todos = this.data.todos
    var remove = todos.splice(index, 1)[0]
    this.setData({
      todos: todos,
      leftCount: this.data.leftCount - (remove.completed ? 0 : 1)
    })
    this.save()
  },

  clearCompletedHandle: function (e) {
    var todos = this.data.todos
    var remains = []
    for (var i = 0; i < todos.length; i++) {
      todos[i].completed || remains.push(todos[i])
    }
    this.setData({ todos: remains })
    this.save()
  }

})
