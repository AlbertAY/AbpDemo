<template>
  <div id="app">
    <el-row :gutter="10">
      <el-col :span="2">A发送内容:</el-col>
      <el-col :span="6">
        <el-input type="textarea" :rows="2" placeholder="请输入内容" v-model="textarea"></el-input>
      </el-col>
      <el-col :span="2">
        <el-button type="primary">发送</el-button>
      </el-col>
    </el-row>
    <el-row :gutter="10">
      <el-col>
        <div style="height:20px"></div>
      </el-col>
    </el-row>
    <el-row :gutter="10">
      <el-col :span="2">聊天内容:</el-col>
      <el-col :span="6">
        <el-input type="textarea" :rows="10" placeholder="请输入内容" v-model="textarea"></el-input>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  name: "app",
  data() {
    return {
      textarea: ""
    };
  }
};
</script>