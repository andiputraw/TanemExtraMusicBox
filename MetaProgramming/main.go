package main

import (
	"fmt"
	"io"
	"log"
	"os"
	"strings"
	"text/template"
)

var program = "??"

const ModName = "TanemExtraMusicBox"

const MusicPath = "Content/Items/MusicBox"
const MusicTemplatePath = "MetaProgramming/Template/MusicBox"
const MusicTemplateName = "music.tmpl"
const MusicTileTemplateName = "musicTile.tmpl"
const MusicSpriteName = "music.png"
const MusicSpriteTile = "musicTile.png"
const musicSpriteHighlight = "musicTile_Highlight.png"

func copyFile(src, dst string) error {
	source, err := os.Open(src)
	if err != nil {
		return fmt.Errorf("failed to open source file: %w", err)
	}

	defer source.Close()

	dstFile, err := os.Create(dst)

	if err != nil {
		return fmt.Errorf("failed to open destination file: %w", err)
	}

	defer dstFile.Close()

	_, err = io.Copy(dstFile, source)

	if err != nil {
		return fmt.Errorf("failed to copy file: %w", err)
	}

	if err = dstFile.Sync(); err != nil {
		return fmt.Errorf("failed to sync destination file: %w", err)
	}

	return nil
}

func GenerateMusicSprite(path, musicName, tileName string) {
	var copies [][]string = [][]string{
		{musicName + ".png", "music.png"},
		{tileName + ".png", "musicTile.png"},
		{tileName + "_Highlight.png", "musicTile_Highlight.png"},
	}

	for _, v := range copies {
		src := fmt.Sprintf("%s/%s", MusicTemplatePath, v[1])
		dst := fmt.Sprintf("%s/%s", path, v[0])
		if err := copyFile(src, dst); err != nil {
			log.Fatalf("Failed to copy sprite files: %v", err)
		}
	}

}

func DefaultValue[T any](in *T, def T) T {
	if in == nil {
		return def
	}

	return *in
}

func main() {
	cwd, err := os.Getwd()

	if err != nil {
		log.Fatalf("Cannot get current work directory\n")
	}

	paths := strings.Split(cwd, string(os.PathSeparator))
	
	if paths[len(paths)-1] != ModName {
		log.Fatalf("Please execute on the root of the mod file")
	}

	if len(os.Args) < 2 {
		ListOfCommand()
		log.Fatalf("Command not provided")
	}
	program = os.Args[0]
	command := os.Args[1]
	params := os.Args[2:]

	switch command {
	case "music":
		MusicCommand(cwd, params)
	default:
		log.Fatalf("[ERROR] Command not found")
	}

	// mandatory := []*string{music}
	// CheckMandatory(mandatory)
}

type MusicTemplateParam struct {
	MusicBoxName string
	TileName     string
	MusicName    string
}

func ListOfCommand() {
	log.Printf("music [music box name] [music name] - Create a music box with the given name and music name")
}

func MusicHelp() {
	log.Printf("%s music [music box name] [music name]\n", program)
}

func MusicCommand(cwd string, params []string) {
	if len(params) < 2 {
		MusicHelp()
		log.Fatalf("Argument not enough")
	}

	param := MusicTemplateParam{
		MusicBoxName: params[0],
		MusicName:    params[1],
		TileName:     fmt.Sprintf("%sTile", params[0]),
	}

	generalPath := fmt.Sprintf("%s/%s/%s", cwd, MusicPath, param.MusicBoxName)

	if err := os.Mkdir(generalPath, os.ModePerm); err != nil {
		log.Fatalf("Cannot create a directory %s : %v", generalPath, err)
	}

	musicFile, err := os.Create(fmt.Sprintf("%s/%s.cs", generalPath, param.MusicBoxName))

	if err != nil {
		log.Fatalf("Cannot create a file %s : %v", param.MusicBoxName, err)
	}
	defer musicFile.Close()

	musicTileFile, err := os.Create(fmt.Sprintf("%s/%s.cs", generalPath, param.TileName))

	if err != nil {
		log.Fatalf("Cannot create a file %s : %v", param.MusicBoxName, err)
	}

	defer musicTileFile.Close()

	musicBoxTemplate, err := template.New(MusicTemplateName).ParseFiles(fmt.Sprintf("%s/%s/%s", cwd, MusicTemplatePath, MusicTemplateName))

	if err != nil {
		log.Fatalf("Cannot create template file %s", err.Error())
	}

	musicTileTemplate, err := template.New(MusicTileTemplateName).ParseFiles(fmt.Sprintf("%s/%s/%s", cwd, MusicTemplatePath, MusicTileTemplateName))

	if err = musicBoxTemplate.Execute(musicFile, param); err != nil {
		log.Fatalf("Cannot execute template file %s", err.Error())
	}

	if err = musicTileTemplate.Execute(musicTileFile, param); err != nil {
		log.Fatalf("Cannot execute template file %s", err.Error())
	}
	GenerateMusicSprite(generalPath, param.MusicBoxName, param.TileName)
	log.Printf("Created music box with name %s in %s/%s/%s", param.MusicBoxName, cwd, MusicPath, param.MusicBoxName)

}
