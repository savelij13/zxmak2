
Не разбираюсь в пошарпанном си, нужна подсказка.
TODO:
- как убрать консоль при запуске?
- как собрать релизную версию без отладочных *.pdb файлов?
- как перевести на текущий DirectX вместо изначальной 9-й версии?

History:
06.02.2023 (2.9.3.9):
- добавлена поддержка Slave IDE через настройку в файле zxmak2.vmide для всех IDE. В связи с изменениями
	вместо аттрибута Image надо указывать ImageMaster или ImageSlave соответственно в файле настроек.
	Пример файла zxmak2.vmide:
	<IdeDiskDescriptor>
	  <ImageMaster fileName="cf128mb.img" isReadOnly="True" isCdrom="False" serial="00000000001234567890" revision="8" model="ZXMAK2 HDD MASTER IMAGE" />
	  <Geometry cylinders="250" heads="16" sectors="63" lba="252000" />
	</IdeDiskDescriptor>
